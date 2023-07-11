using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class WaypointsInitializer : IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<WaypointComponent>> _waypointsFilter;
        private readonly EcsCustomInject<SharedData> _data;

        public void Init(IEcsSystems systems)
        {
            var waypointPool = _waypointsFilter.Pools.Inc1;
            
            foreach (var entity in _waypointsFilter.Value)
            {
                ref WaypointComponent waypointComponent = ref waypointPool.Get(entity);
                waypointComponent.StartPos = GetRandomPosition();
                waypointComponent.EndPos = GetRandomPosition();
                waypointComponent.TargetPos = waypointComponent.StartPos;
            }
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(
                Random.Range(-_data.Value.BorderX, _data.Value.BorderX),
                0f,
                Random.Range(-_data.Value.BorderZ, _data.Value.BorderZ)
            );
        }
    }
}