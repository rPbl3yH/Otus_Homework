using System;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class InputSystem : MonoBehaviour
    {
        public event Action<Vector3> OnDirectionChanged;

        private void Update()
        {
            var direction = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));
            OnDirectionChanged?.Invoke(direction);
        }
    }
}