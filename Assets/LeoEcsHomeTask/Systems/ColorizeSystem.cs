using System.Threading.Tasks;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class ColorizeSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitVisionComponent>> _visionFilter;
        private readonly EcsPoolInject<UnitVisionComponent> _visionPool;
        private readonly EcsPoolInject<ColorComponent> _colorPool;
        private readonly EcsWorldInject _world;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _visionFilter.Value)
            {
                ref var unitVision = ref _visionPool.Value.Get(entity);

                (int, int) entitiesCollide = PackerEntityUtils.UnpackEntities(_world.Value,
                    unitVision.FirstCollide.PackedEntity, unitVision.SecondCollide.PackedEntity);

                ref var firstColor = ref _colorPool.Value.Get(entitiesCollide.Item1);

                ref var secondColor = ref _colorPool.Value.Get(entitiesCollide.Item2);
                _world.Value.DelEntity(entity);
            }
        }
    }
}