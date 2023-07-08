using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Entities.Components
{
    public interface IMoveComponent
    {
        public void Move(Vector3 direction);
    }
    
    public class MoveComponent : IMoveComponent
    {
        private IAtomicAction<Vector3> _onMove;
        
        public MoveComponent(IAtomicAction<Vector3> onMove)
        {
            _onMove = onMove;
        }

        public void Move(Vector3 direction)
        {
            _onMove?.Invoke(direction);
        }
    }
}