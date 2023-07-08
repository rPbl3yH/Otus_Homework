using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class CameraMoveEngine: ILateUpdateListener
    {
        private Transform _target;
        private Transform _cameraTransform;
        private bool _isMoveRequired;
        
        public void Construct(Transform cameraTransform, Transform target)
        {
            _cameraTransform = cameraTransform;
            _target = target;
        }

        public void Move()
        {
            _isMoveRequired = true;
        }

        public void LateUpdate(float deltaTime)
        {
            if (_isMoveRequired)
            {
                _cameraTransform.position = _target.position;
            }
        }
    }
}