using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveInput : MonoBehaviour
    {
        public float HorizontalDirection { get; private set; }

        [SerializeField]
        private MoveComponent _moveComponent;

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
        }

        private void FixedUpdate() {
            _moveComponent.MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}
