using UnityEngine;

namespace AtomicHomework.Entities.Components
{
    public interface IMoveComponent
    {
        public void Move(Vector3 direction);
    }
}