using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletCollisionObserver : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;

        private void OnEnable() {
            _bulletPool.OnBulletAdded += OnBulletAdded;
            _bulletPool.OnBulletRemoved += OnBulletRemoved;
        }

        private void OnDisable() {
            _bulletPool.OnBulletAdded -= OnBulletAdded;
            _bulletPool.OnBulletRemoved -= OnBulletRemoved;
        }

        private void OnBulletRemoved(Bullet bullet) {
            bullet.OnCollisionEntered -= OnBulletCollision;
        }

        private void OnBulletAdded(Bullet bullet) {
            bullet.OnCollisionEntered += OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision) {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            _bulletPool.Despawn(bullet);
        }
    }
}
