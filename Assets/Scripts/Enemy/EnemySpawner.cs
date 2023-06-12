using System.Collections;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnTime;
        private Pool<Enemy> _enemyPool;
        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(Pool<Enemy> pool, EnemyFactory enemyFactory) {
            _enemyPool = pool;
            _enemyFactory = enemyFactory;
        }

        private IEnumerator Start() {
            while (true) {
                yield return new WaitForSeconds(_spawnTime);
                var enemy = _enemyFactory.Spawn();

                if (enemy != null) {
                    _enemyPool.AddToActiveItems(enemy);
                }
            }
        }
    }
}
