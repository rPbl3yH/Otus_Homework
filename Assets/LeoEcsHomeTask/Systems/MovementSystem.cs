using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<WaypointComponent, BlockViewComponent>> _blockFilter;
        private readonly EcsPoolInject<WaypointComponent> _waypointPool;
        private readonly EcsPoolInject<BlockViewComponent> _blockViewPool;
        private readonly EcsCustomInject<SharedData> _data;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _blockFilter.Value)
            {
                ref var blockView = ref _blockViewPool.Value.Get(entity);
                ref var waypoint = ref _waypointPool.Value.Get(entity);
                
                blockView.View.transform.position = Vector3.MoveTowards(
                    blockView.View.transform.position, 
                    waypoint.TargetPos,
                    Time.deltaTime * _data.Value.Speed);
                
                if((blockView.View.transform.position - waypoint.StartPos).sqrMagnitude < 0.1f)
                {
                    waypoint.TargetPos = waypoint.EndPos;
                }

                if ((blockView.View.transform.position - waypoint.EndPos).sqrMagnitude < 0.1f)
                {
                    waypoint.TargetPos = waypoint.StartPos;
                }                
            }
        }
    }
}