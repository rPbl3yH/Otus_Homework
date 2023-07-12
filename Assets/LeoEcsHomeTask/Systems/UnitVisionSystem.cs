using System.Threading.Tasks;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class UnitVisionSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitVisionComponent>> _visionFilter;
        private readonly EcsPoolInject<UnitVisionComponent> _visionPool;
        private readonly EcsPoolInject<ColorComponent> _colorPool;
        private readonly EcsPoolInject<BulletSpawnComponent> _bulletSpawnPool;
        private readonly EcsPoolInject<TeamComponent> _teamPool;
        private readonly EcsWorldInject _world;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _visionFilter.Value)
            {
                ref var unitVision = ref _visionPool.Value.Get(entity);


                (int, int) visionUnits = PackerEntityUtils.UnpackEntities(_world.Value,
                    unitVision.FirstCollide.PackedEntity, unitVision.SecondCollide.PackedEntity);

                ref var teamFirst = ref _teamPool.Value.Get(visionUnits.Item1);
                ref var teamSecond = ref _teamPool.Value.Get(visionUnits.Item2);

                if (teamFirst.IsRed != teamSecond.IsRed)
                {
                    int newEntity = _world.Value.NewEntity();
                
                    ref BulletSpawnComponent bulletSpawn = ref _bulletSpawnPool.Value.Add(newEntity);
                    bulletSpawn.SourceUnit = unitVision.FirstCollide;
                    bulletSpawn.TargetUnit = unitVision.SecondCollide;
                }
                
                _world.Value.DelEntity(entity);
            }
        }
    }
}