using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LeoEcsHomeTask.Systems
{
    public class BlockEntityInitializer : IEcsInitSystem
    {
        private readonly EcsCustomInject<SharedRedData> _redData;
        private readonly EcsCustomInject<SharedBlueData> _blueData;
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            AddEntities(world, _redData.Value);
            AddEntities(world, _blueData.Value);
        }

        private void AddEntities(EcsWorld world, SharedData data)
        {
            EcsPool<HealthComponent> healthPool = world.GetPool<HealthComponent>();
            EcsPool<ColorComponent> colorPool = world.GetPool<ColorComponent>();
            EcsPool<ViewComponent> blockViewPool = world.GetPool<ViewComponent>();
            EcsPool<WaypointComponent> waypointPool = world.GetPool<WaypointComponent>();
            EcsPool<TeamComponent> teamPool = world.GetPool<TeamComponent>();

            for (int i = 0; i < data.SpawnCount; i++)
            {
                var entity = world.NewEntity();
                blockViewPool.Add(entity);
                healthPool.Add(entity).Health = data.Health;
                colorPool.Add(entity);
                teamPool.Add(entity).IsRed = data.IsRed;
                waypointPool.Add(entity);
            }
        }
    }
}