using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : MonoBehaviour {

        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private MoveInput _moveInput;

        private void OnEnable() {
            _moveInput.OnMove += Move;
        }

        private void OnDisable() {
            _moveInput.OnMove -= Move;
        }

        private void Move(float movementX) {
            var direction = new Vector2(movementX, 0) * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}
