using Declarative;
using Lessons.Gameplay.Atomic1;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class RotateEngine : IUpdateListener
    {
        private Transform _transform;
        private IAtomicValue<float> _speed;
        private IAtomicValue<Vector3> _rotateDirection;

        private bool _isRotateRequired;
        
        public void Construct(Transform transform, IAtomicValue<float> speed, IAtomicValue<Vector3> rotateDirection)
        {
            _transform = transform;
            _speed = speed;
            _rotateDirection = rotateDirection;
        }

        public void Rotate()
        {
            _isRotateRequired = true;
        }

        public void Update(float deltaTime)
        {
            if (_isRotateRequired)
            {
                _transform.Rotate(_rotateDirection.Value * (_speed.Value * deltaTime));
                _isRotateRequired = false;
            }
        }
    }
}