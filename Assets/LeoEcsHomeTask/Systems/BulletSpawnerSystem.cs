using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LeoEcsHomeTask.Systems
{
    public class BulletSpawnerSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageComponent, ViewComponent, ColorComponent, TeamComponent>> _blockFilter;
        private readonly EcsCustomInject<SharedBlueData> _blueData;
        private readonly EcsCustomInject<SharedRedData> _redData;
        private readonly EcsCustomInject<UnitData> _unitData;
        
        public void Run(IEcsSystems systems)
        {
            
        }
    }
}