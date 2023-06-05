using UnityEngine;

namespace ShootEmUp
{
	public sealed class EnemyPoolInstaller : MonoBehaviour {

        [SerializeField] private float _initialCount = 7;
		[SerializeField] private Transform _container;
		[SerializeField] private EnemyFactory _enemyFactory;
		[SerializeField] private EnemySpawner _enemySpawner;
		[SerializeField] private EnemiesObserver _enemiesObserver;

        private Pool<Enemy> _enemyPool;

		private void Awake() {
			_enemyPool = new Pool<Enemy>(_container);
			_enemyFactory.Construct(_enemyPool);
			_enemySpawner.Construct(_enemyPool);
			_enemiesObserver.Construct(_enemyPool);

			for (var i = 0; i < _initialCount; i++) {
				var enemy = _enemyFactory.Create(_container);
				_enemyPool.Add(enemy);
			}
		}
	}
}