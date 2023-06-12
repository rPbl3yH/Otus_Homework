using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool IsPlayer { get; private set; }
        public int Damage { get; private set; }

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision) {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetDamage(int damage) {
            Damage = damage;
        }

        public void SetTeam(bool isPlayer) {
            IsPlayer = isPlayer;
        }

        public void SetVelocity(Vector2 velocity) {
            _rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer) {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position) {
            transform.position = position;
        }

        public void SetColor(Color color) {
            _spriteRenderer.color = color;
        }
    }
}
