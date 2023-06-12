using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletLauncher : MonoBehaviour
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
            }
            else {
                bullet = _bulletFactory.Create(_worldTransform);
                _bulletPool.AddToActiveItems(bullet);
            }

            SetupBullet(bullet, bulletData);
            _bulletPool.AddToActiveItems(bullet);

            return bullet;
        }

        public void SetupBullet(Bullet bullet, BulletData bulletData) {
            bullet.SetColor(bulletData.Color);
            bullet.SetDamage(bulletData.Damage);
            bullet.SetPhysicsLayer(bulletData.PhysicsLayer);
            bullet.SetPosition(bulletData.Position);
            bullet.SetVelocity(bulletData.Velocity);
            bullet.SetTeam(bulletData.IsPlayer);
        }
    }
}
