using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public class BulletPoolInstaller : MonoInstaller<BulletPoolInstaller> {

		[SerializeField] private int _initialCount = 50;
		[SerializeField] private Transform _worldTransform;
		[SerializeField] private Transform _container;
		[SerializeField] private BulletFactory _bulletFactory;

		private Pool<Bullet> _bulletPool;

		public override void InstallBindings()
		{
			_bulletPool = new Pool<Bullet>(_container);
			Container.Bind<Pool<Bullet>>().FromInstance(_bulletPool).AsSingle();
		}

		private void Awake() {
			for (var i = 0; i < _initialCount; i++) {
				var bullet = _bulletFactory.Create(_worldTransform);
				_bulletPool.Add(bullet);
			}
		}
	}
}
