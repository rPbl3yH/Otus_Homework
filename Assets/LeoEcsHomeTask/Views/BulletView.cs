using UnityEngine;

namespace LeoEcsHomeTask.Views
{
    public class BulletView : EcsMonoObject
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UnitView unitView))
            {
                OnTriggerAction(this, unitView);
            }
        }

        private void OnTriggerAction(BulletView bulletView, UnitView secondUnit)
        {
            if (World != null)
            {
                int entity = World.NewEntity();
                var hitPool = World.GetPool<HitComponent>();
                ref HitComponent hit = ref hitPool.Add(entity);

                hit.BulletView = bulletView;
                hit.UnitView = secondUnit;
            }
        }
    }
}