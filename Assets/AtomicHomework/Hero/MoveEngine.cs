using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class MoveEngine : IFixedUpdateListener
    {
        private Transform _transform;
        private Vector3 _direction;
        private IAtomicValue<float> _speed;
        private bool _isMoveRequired;

        public void Construct(Transform transform, IAtomicValue<float> speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            _direction = direction;
            _isMoveRequired = true;
        }

        public void FixedUpdate(float deltaTime)
        {
            if (_isMoveRequired)
            {
                _transform.position += _direction * (_speed.Value * deltaTime);
                _isMoveRequired = false;
            }   
        }
    }
}