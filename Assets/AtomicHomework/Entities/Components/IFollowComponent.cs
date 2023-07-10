using UnityEngine;

namespace AtomicHomework.Entities.Components
{
    public interface IFollowComponent
    {
        public void Follow(Transform transform);
    }
}