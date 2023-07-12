using LeoEcs.Systems;
using LeoEcsHomeTask.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class UnitSpawner : IEcsInitSystem
    {
        private readonly EcsFilterInject<Inc<WaypointComponent, ViewComponent, ColorComponent, TeamComponent>> _unitFilter;
        private readonly EcsCustomInject<SharedBlueData> _blueData;
        private readonly EcsCustomInject<SharedRedData> _redData;
        private readonly EcsCustomInject<UnitData> _unitData;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var waypointsPool = _unitFilter.Pools.Inc1;
            var blockViewPool = _unitFilter.Pools.Inc2;
            var colorPool = _unitFilter.Pools.Inc3;
            var teamPool = _unitFilter.Pools.Inc4;
            
            foreach (var entity in _unitFilter.Value)
            {
                ref var waypointComponent = ref waypointsPool.Get(entity);
                
                var newObject = Object.Instantiate(
                    Resources.Load<EcsMonoObject>(_unitData.Value.Path),
                    waypointComponent.StartPos,
                    Quaternion.identity
                );
                
                newObject.Init(world);
                newObject.PackEntity(entity);
                
                ref var blockViewComponent = ref blockViewPool.Get(entity);
                blockViewComponent.View = newObject.gameObject;

                ref var teamComponent = ref teamPool.Get(entity);
                
                ref var colorComponent = ref colorPool.Get(entity);
                colorComponent.Renderer = newObject.GetComponent<MeshRenderer>();
                colorComponent.Renderer.material.color = teamComponent.IsRed ? _redData.Value.Color : _blueData.Value.Color;
            }
        }
    }
}