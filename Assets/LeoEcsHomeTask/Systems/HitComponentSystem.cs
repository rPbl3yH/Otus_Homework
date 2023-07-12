using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class HitComponentSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageComponent, ViewComponent, TeamComponent>> _bulletFilter;
        private readonly EcsFilterInject<Inc<HitComponent>> _hitFilter;
        private readonly EcsPoolInject<BulletSpawnComponent> _bulletPool;
        private readonly EcsCustomInject<UnitData> _unitData;
        private readonly EcsCustomInject<BulletData> _bulletData;
        private readonly EcsWorldInject _world;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _hitFilter.Value)
            {
                ref var hit = ref _hitFilter.Pools.Inc1.Get(entity);

                (int, int) hitEntities = PackerEntityUtils.UnpackEntities(_world.Value, hit.BulletView.PackedEntity,
                    hit.UnitView.PackedEntity);

                ref var bulletTeam = ref _bulletFilter.Pools.Inc3.Get(hitEntities.Item1);
                ref var unitTeam = ref _bulletFilter.Pools.Inc3.Get(hitEntities.Item2);

                if (bulletTeam.IsRed != unitTeam.IsRed)
                {
                    ref var bulletView = ref _bulletFilter.Pools.Inc2.Get(hitEntities.Item1);
                    Object.DestroyImmediate(bulletView.View.gameObject); 
                }

                _world.Value.DelEntity(entity);
            }
        }
    }
}