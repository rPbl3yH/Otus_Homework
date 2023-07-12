using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class BlockSpawner : IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<WaypointComponent, BlockViewComponent, ColorComponent, TeamComponent>> _blockFilter;
        private readonly EcsCustomInject<SharedBlueData> _blueData;
        private readonly EcsCustomInject<SharedRedData> _redData;
        private readonly EcsCustomInject<UnitData> _unitData;

        public void Init(IEcsSystems systems)
        {
            var waypointsPool = _blockFilter.Pools.Inc1;
            var blockViewPool = _blockFilter.Pools.Inc2;
            var colorPool = _blockFilter.Pools.Inc3;
            var teamPool = _blockFilter.Pools.Inc4;
            
            foreach (var entity in _blockFilter.Value)
            {
                ref var waypointComponent = ref waypointsPool.Get(entity);
                
                var newObject = Object.Instantiate(
                    Resources.Load<GameObject>(_unitData.Value.Path),
                    waypointComponent.StartPos,
                    Quaternion.identity
                );
                
                ref var blockViewComponent = ref blockViewPool.Get(entity);
                blockViewComponent.View = newObject;

                ref var teamComponent = ref teamPool.Get(entity);
                
                ref var colorComponent = ref colorPool.Get(entity);
                colorComponent.Renderer = newObject.GetComponent<MeshRenderer>();
                colorComponent.Renderer.material.color = teamComponent.IsRed ? _redData.Value.Color : _blueData.Value.Color;
            }
        }
    }
}