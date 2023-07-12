using UnityEngine;

namespace LeoEcsHomeTask.Views
{
    public class UnitView : EcsMonoObject
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UnitView unitView))
            {
                OnTriggerAction(this, unitView);
            }
        }

        private void OnTriggerAction(UnitView firstUnit, UnitView secondUnit)
        {
            if (World != null)
            {
                int entity = World.NewEntity();
                var visionPool = World.GetPool<UnitVisionComponent>();
                ref UnitVisionComponent vision = ref visionPool.Add(entity);

                vision.FirstCollide = firstUnit;
                vision.SecondCollide = secondUnit;
            }
        }
    }
}