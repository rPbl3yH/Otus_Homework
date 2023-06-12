using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletService : MonoBehaviour
    {
        [SerializeField] private Transform _worldTransform;

        private BulletFactory _bulletFactory;
        private Pool<Bullet> _bulletPool;

        [Inject]
        public void Construct(Pool<Bullet> pool, BulletFactory bulletFactory) {
            _bulletPool = pool;
            _bulletFactory = bulletFactory;
        }

        public Bullet SpawnBullet(BulletData bulletData) {
            if (_bulletPool.TryDequeue(out var bullet)) {
                bullet.transform.SetParent(_worldTransform);
                _bulletFactory.SetupBullet(bullet, bulletData);
            }
            else {
                bullet = _bulletFactory.Create(bulletData, _worldTransform);
            }

            _bulletPool.AddToActiveItems(bullet);

            return bullet;
        }
    }
}
