using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class DestroySystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<HealthComponent, ViewComponent>> _healthFilter;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _healthFilter.Value)
            {
                ref var health = ref _healthFilter.Pools.Inc1.Get(entity);

                if (health.Health <= 0)
                {
                    ref var view = ref _healthFilter.Pools.Inc2.Get(entity);
                    Object.DestroyImmediate(view.View);
                }
            }
        }
    }
}