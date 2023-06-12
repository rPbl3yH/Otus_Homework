using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private Character _character;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Enemy _prefab;

        private Pool<Enemy> _enemyPool;

        [Inject]
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

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.EnemyMoveAgent.SetDestination(attackPosition.position);

            enemy.EnemyAttackAgent.SetTarget(_character.gameObject);
            return enemy;
        }
    }
}
