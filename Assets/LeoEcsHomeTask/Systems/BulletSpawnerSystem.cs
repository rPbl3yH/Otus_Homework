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
                var bulletEntity = _world.Value.NewEntity();
                ref var damage = ref _bulletFilter.Pools.Inc1.Add(bulletEntity);
                ref var view = ref _bulletFilter.Pools.Inc2.Add(bulletEntity);
                ref var color = ref _bulletFilter.Pools.Inc3.Add(bulletEntity);
                ref var team = ref _bulletFilter.Pools.Inc4.Add(bulletEntity);

                (int, int) collideEntity = PackerEntityUtils.UnpackEntities(_world.Value,
                    bulletSpawn.SourceUnit.PackedEntity, bulletSpawn.TargetUnit.PackedEntity);
                
                ref var unitTeam = ref _bulletFilter.Pools.Inc4.Get(collideEntity.Item1);
                team.IsRed = unitTeam.IsRed;

                ref var unitView = ref _bulletFilter.Pools.Inc2.Get(collideEntity.Item1);
                ref var targetUnitView = ref _bulletFilter.Pools.Inc2.Get(collideEntity.Item2);
                
                damage.DamageValue = _bulletData.Value.Damage;

                var position = unitView.View.transform.position;
                var bullet = Object.Instantiate(
                    Resources.Load<EcsMonoObject>(_bulletData.Value.Path),
                    position,
                    Quaternion.LookRotation(targetUnitView.View.transform.position - position)
                );
                
                bullet.Init(_world.Value);
                bullet.PackEntity(bulletEntity);

                view.View = bullet.gameObject;
                
                ref var unitColor = ref _bulletFilter.Pools.Inc3.Get(collideEntity.Item1);
                color.Renderer = bullet.gameObject.GetComponent<MeshRenderer>();
                color.Renderer.material.color = unitColor.Renderer.material.color;
                
                _world.Value.DelEntity(entity);
            }
        }
    }
}