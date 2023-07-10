using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Entities.Components
{
    public class FollowComponent : IFollowComponent
    {
        private readonly IAtomicAction<Transform> _onFollow;

        public FollowComponent(IAtomicAction<Transform> onFollow)
        {
            _onFollow = onFollow;
        }

        public void Follow(Transform transform)
        {
            _onFollow?.Invoke(transform);
        }
    }
}