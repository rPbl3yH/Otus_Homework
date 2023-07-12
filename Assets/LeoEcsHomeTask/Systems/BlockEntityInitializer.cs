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
            AddEntity(world, _redData.Value);
            AddEntity(world, _blueData.Value);
        }

        private void AddEntity(EcsWorld world, SharedData data)
        {
            EcsPool<HealthComponent> healthPool = world.GetPool<HealthComponent>();
            EcsPool<ColorComponent> colorPool = world.GetPool<ColorComponent>();
            EcsPool<DamageComponent> damagePool = world.GetPool<DamageComponent>();
            EcsPool<BlockViewComponent> blockViewPool = world.GetPool<BlockViewComponent>();
            EcsPool<WaypointComponent> waypointPool = world.GetPool<WaypointComponent>();
            EcsPool<TeamComponent> teamPool = world.GetPool<TeamComponent>();

            for (int i = 0; i < data.SpawnCount; i++)
            {
                var entity = world.NewEntity();
                blockViewPool.Add(entity);
                healthPool.Add(entity).Health = data.Health;
                damagePool.Add(entity).DamageValue = data.Damage;
                colorPool.Add(entity);
                teamPool.Add(entity).IsRed = data.IsRed;
                waypointPool.Add(entity);
            }
        }
    }
}