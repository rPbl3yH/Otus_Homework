using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LeoEcsHomeTask.Systems
{
    public class BlockInitializer : IEcsInitSystem
    {
        private readonly EcsCustomInject<SharedData> _data;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            EcsPool<HealthComponent> healthPool = world.GetPool<HealthComponent>();
            EcsPool<ColorComponent> colorPool = world.GetPool<ColorComponent>();
            EcsPool<DamageComponent> damagePool = world.GetPool<DamageComponent>();
            EcsPool<BlockViewComponent> blockViewPool = world.GetPool<BlockViewComponent>();
            EcsPool<WaypointComponent> waypointPool = world.GetPool<WaypointComponent>();

            for (int i = 0; i < _data.Value.SpawnCount; i++)
            {
                var entity = world.NewEntity();
                blockViewPool.Add(entity);
                healthPool.Add(entity).Health = _data.Value.Health;
                damagePool.Add(entity).DamageValue = _data.Value.Damage;
                colorPool.Add(entity);
                waypointPool.Add(entity);
            }
        }
    }
}