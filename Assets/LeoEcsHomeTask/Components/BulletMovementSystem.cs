using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask
{
    public class BulletMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<ViewComponent, DamageComponent>> _bulletFilter;
        private readonly EcsCustomInject<BulletData> _bulletData;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _bulletFilter.Value)
            {
                ref var view = ref _bulletFilter.Pools.Inc1.Get(entity);

                if (view.View != null)
                {
                    view.View.transform.Translate(Vector3.forward * _bulletData.Value.Speed * Time.deltaTime);
                }
            }
        }
    }
}