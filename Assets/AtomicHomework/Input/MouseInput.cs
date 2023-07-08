using System;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class MouseInput : MonoBehaviour
    {
        public event Action<Vector2> OnDirectionChanged;
        private Vector3 _lastPosition;
    
        private void Update()
        {
            var mousePosition = UnityEngine.Input.mousePosition;
            if (_lastPosition != mousePosition)
            {
                var direction = mousePosition - _lastPosition;
                _lastPosition = mousePosition;
                direction.Normalize();
                OnDirectionChanged?.Invoke(direction);
            }
        }
    }
}
