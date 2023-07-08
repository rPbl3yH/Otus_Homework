using System;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class MouseInputObserver : MonoBehaviour
    {
        [SerializeField] private MouseInput _mouseInput;
        
        public event Action<Vector3> OnRotateDirectionChanged;

        private void Awake()
        {
            _mouseInput.OnDirectionChanged += OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2 direction)
        {
            var rotateDirection = new Vector3(0f, direction.x, 0f);
            OnRotateDirectionChanged?.Invoke(rotateDirection);
        }
    }
}