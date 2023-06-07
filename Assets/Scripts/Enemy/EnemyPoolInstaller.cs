using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public sealed class EnemyPoolInstaller : MonoInstaller<EnemyPoolInstaller> {

        [SerializeField] private float _initialCount = 7;
		[SerializeField] private Transform _container;

		[Inject]
		private EnemyFactory _enemyFactory;

        private Pool<Enemy> _enemyPool;

		public override void InstallBindings()
		{
			_enemyPool = new Pool<Enemy>(_container);
			Container.Bind<Pool<Enemy>>().FromInstance(_enemyPool).AsSingle();
		}

		private void Awake() {
			for (var i = 0; i < _initialCount; i++) {
				var enemy = _enemyFactory.Create(_container);
				_enemyPool.Add(enemy);
			}
		}
	}
}