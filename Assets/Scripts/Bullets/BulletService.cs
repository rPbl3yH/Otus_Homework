using UnityEngine;

namespace ShootEmUp
{
	public sealed class BulletService : MonoBehaviour
    {
		[SerializeField] private BulletFactory _bulletFactory;
		[SerializeField] private Transform _worldTransform;

		private Pool<Bullet> _bulletPool;

		public void Construct(Pool<Bullet> pool) {
			_bulletPool = pool;
		}

		public Bullet SpawnBullet(BulletData bulletData) {
			if (_bulletPool.TryDequeue(out var bullet)) {
				bullet.transform.SetParent(_worldTransform);
				_bulletFactory.SetupBullet(bullet, bulletData);
			}
			else {
				bullet = _bulletFactory.Create(bulletData, _worldTransform);
			}

			_bulletPool.AddToActiveBullets(bullet);

			return bullet;
		}
	}
}
