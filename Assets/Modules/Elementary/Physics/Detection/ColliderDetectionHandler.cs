using UnityEngine;

namespace Elementary
{
    public abstract class ColliderDetectionHandler : MonoBehaviour
    {
        [SerializeField]
        private ColliderDetectionOverlapSphere sensor;

        protected virtual void OnEnable()
        {
            this.sensor.OnCollidersUpdated += this.OnCollidersUpdated;
        }

        protected virtual void OnDisable()
        {
            this.sensor.OnCollidersUpdated -= this.OnCollidersUpdated;
        }

        protected void OnCollidersUpdated()
        {
            this.sensor.GetCollidersUnsafe(out var buffer, out var size);
            this.OnCollidersUpdated(buffer, size);
        }

        protected abstract void OnCollidersUpdated(Collider[] buffer, int size);
    }
}