using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class WaypointsInitializer : IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<WaypointComponent, TeamComponent>> _blockFilter;
        private readonly EcsCustomInject<SharedBlueData> _blueData;
        private readonly EcsCustomInject<SharedRedData> _redData;

        public void Init(IEcsSystems systems)
        {
            var waypointPool = _blockFilter.Pools.Inc1;
            var teamPool = _blockFilter.Pools.Inc2;
            
            foreach (var entity in _blockFilter.Value)
            {
                ref var waypoint = ref waypointPool.Get(entity);
                ref var team = ref teamPool.Get(entity);

                if (team.IsRed)
                {
                    waypoint.StartPos = GetPosition(_redData.Value.SpawnPoint.position, _redData.Value.SpawnDistance);
                    waypoint.EndPos = GetPosition(_blueData.Value.SpawnPoint.position, _blueData.Value.SpawnDistance);
                    waypoint.TargetPos = waypoint.StartPos;
                }
                else
                {
                    waypoint.StartPos = GetPosition(_blueData.Value.SpawnPoint.position, _blueData.Value.SpawnDistance);
                    waypoint.EndPos = GetPosition(_redData.Value.SpawnPoint.position, _redData.Value.SpawnDistance);
                    waypoint.TargetPos = waypoint.StartPos;
                }
               
            }
        }

        private Vector3 GetPosition(Vector3 position, int spawnDistance)
        {
            var pointPosition = position;
            var randomOffset = new Vector3(
                Random.Range(-spawnDistance, spawnDistance),
                0f,
                Random.Range(-spawnDistance, spawnDistance));

            return pointPosition + randomOffset;
        }
    }
}