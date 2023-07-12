using LeoEcs.Systems;
using LeoEcsHomeTask.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class BulletSpawnerSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageComponent, ViewComponent, ColorComponent, TeamComponent>> _bulletFilter;
        private readonly EcsFilterInject<Inc<BulletSpawnComponent>> _bulletSpawnFilter;
        private readonly EcsPoolInject<BulletSpawnComponent> _bulletPool;
        private readonly EcsCustomInject<UnitData> _unitData;
        private readonly EcsCustomInject<BulletData> _bulletData;
        private readonly EcsWorldInject _world;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _bulletSpawnFilter.Value)
            {
                ref var bulletSpawn = ref _bulletPool.Value.Get(entity);
                var newEntity = _world.Value.NewEntity();
                ref var damage = ref _bulletFilter.Pools.Inc1.Add(newEntity);
                ref var view = ref _bulletFilter.Pools.Inc2.Add(newEntity);
                ref var color = ref _bulletFilter.Pools.Inc3.Add(newEntity);
                ref var team = ref _bulletFilter.Pools.Inc4.Add(newEntity);

                (int, int) collideEntity = PackerEntityUtils.UnpackEntities(_world.Value,
                    bulletSpawn.SourceUnit.PackedEntity, bulletSpawn.TargetUnit.PackedEntity);
                
                ref var unitTeam = ref _bulletFilter.Pools.Inc4.Get(collideEntity.Item1);
                team.IsRed = unitTeam.IsRed;

                

                ref var unitView = ref _bulletFilter.Pools.Inc2.Get(collideEntity.Item1);

                damage.DamageValue = _bulletData.Value.Damage;
                
                var bullet = Object.Instantiate(
                    Resources.Load<EcsMonoObject>(_bulletData.Value.Path),
                    unitView.View.transform.position,
                    Quaternion.identity
                );

                view.View = bullet.gameObject;
                
                ref var unitColor = ref _bulletFilter.Pools.Inc3.Get(collideEntity.Item1);
                color.Renderer = bullet.gameObject.GetComponent<MeshRenderer>();
                color.Renderer.material.color = unitColor.Renderer.material.color;
                
                _world.Value.DelEntity(entity);
            }
        }
    }
}