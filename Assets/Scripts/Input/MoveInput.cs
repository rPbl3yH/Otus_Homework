using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveInput : MonoBehaviour
    {
        public event Action<float> OnMove;
        public float HorizontalDirection { get; private set; }

        private void Update() {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) {
                HorizontalDirection = 1;
            }
            else {
                HorizontalDirection = 0;
            }

            OnMove?.Invoke(HorizontalDirection);
        }
    }
}
