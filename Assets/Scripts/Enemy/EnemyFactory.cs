using UnityEngine;

namespace ShootEmUp
{
	public sealed class EnemyFactory : MonoBehaviour {
		[SerializeField] private EnemyPositions enemyPositions;
		[SerializeField] private Character character;
		[SerializeField] private Transform worldTransform;
		[SerializeField] private Enemy _prefab;

		private Pool<Enemy> _enemyPool;

		public void Construct(Pool<Enemy> pool) {
			_enemyPool = pool;
		}

		public Enemy Create(Transform parent) {
			var enemy = Instantiate(_prefab, parent);
			return enemy;
		}

		public Enemy Spawn() {
			if (!_enemyPool.TryDequeue(out Enemy enemy)) {
				return null;
			}

			enemy.transform.SetParent(worldTransform);

			var spawnPosition = enemyPositions.RandomSpawnPosition();
			enemy.transform.position = spawnPosition.position;

			var attackPosition = enemyPositions.RandomAttackPosition();
			enemy.EnemyMoveAgent.SetDestination(attackPosition.position);

			enemy.EnemyAttackAgent.SetTarget(character.gameObject);
			return enemy;
		}
	}
}