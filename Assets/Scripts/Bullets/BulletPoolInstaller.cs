using UnityEngine;

namespace ShootEmUp
{
	public class BulletPoolInstaller : MonoBehaviour {
		[SerializeField] private int _initialCount = 50;

		[SerializeField] private Transform _worldTransform;
		[SerializeField] private Transform _container;
		[SerializeField] private BulletCollisionObserver _bulletCollisionObserver;
		[SerializeField] private BulletCache _bulletCache;
		[SerializeField] private BulletFactory _bulletFactory;
		[SerializeField] private BulletService _bulletService;

		private Pool<Bullet> _bulletPool;

		private void Awake() {
			_bulletPool = new Pool<Bullet>(_container);
			_bulletCollisionObserver.Construct(_bulletPool);
			_bulletCache.Construct(_bulletPool);
			_bulletService.Construct(_bulletPool);

			for (var i = 0; i < _initialCount; i++) {
				var bullet = _bulletFactory.Create(_worldTransform);
				_bulletPool.Add(bullet);
			}
		}
	}
}
