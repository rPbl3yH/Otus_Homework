using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private float _speed = 5.0f;

        public void MoveByRigidbodyVelocity(Vector2 direction) {
            Vector2 nextPosition = _rigidbody2D.position + direction * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }
    }
}
