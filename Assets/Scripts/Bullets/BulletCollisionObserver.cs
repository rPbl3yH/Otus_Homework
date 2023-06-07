using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletCollisionObserver : MonoBehaviour
    {
        private Pool<Bullet> _bulletPool;

        [Inject]
        public void Construct(Pool<Bullet> pool) {
            _bulletPool = pool;
        }

        private void Start() {
            _bulletPool.OnActiveBulletAdded += OnBulletAdded;
            _bulletPool.OnActiveBulletRemoved += OnBulletRemoved;
        }

        private void OnDestroy() {
            _bulletPool.OnActiveBulletAdded -= OnBulletAdded;
            _bulletPool.OnActiveBulletRemoved -= OnBulletRemoved;
        }

        private void OnBulletRemoved(Bullet bullet) {
            bullet.OnCollisionEntered -= OnBulletCollision;
        }

        private void OnBulletAdded(Bullet bullet) {
            bullet.OnCollisionEntered += OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision) {
            bullet.OnCollisionEntered -= OnBulletCollision;
            BulletUtils.DealDamage(bullet, collision.gameObject);
            _bulletPool.Despawn(bullet);
        }
    }
}
