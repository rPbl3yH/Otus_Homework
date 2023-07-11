using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class BlockSpawner : IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<WaypointComponent, BlockViewComponent, ColorComponent>> _blockFilter;
        private readonly EcsCustomInject<SharedData> _data;
        
        public void Init(IEcsSystems systems)
        {
            var waypointsPool = _blockFilter.Pools.Inc1;
            var blockViewPool = _blockFilter.Pools.Inc2;
            var colorPool = _blockFilter.Pools.Inc3;
            
            foreach (var entity in _blockFilter.Value)
            {
                ref var waypointComponent = ref waypointsPool.Get(entity);
                
                var newObject = Object.Instantiate(
                    Resources.Load<GameObject>(_data.Value.Path),
                    waypointComponent.StartPos,
                    Quaternion.identity
                );
                
                ref var blockViewComponent = ref blockViewPool.Get(entity);
                blockViewComponent.View = newObject;

                ref var colorComponent = ref colorPool.Get(entity);
                colorComponent.Renderer = newObject.GetComponent<MeshRenderer>();
                colorComponent.Renderer.material.color = Color.blue;
            }
        }
    }
    
}