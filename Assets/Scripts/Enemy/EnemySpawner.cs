using System.Collections;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public class EnemySpawner : MonoBehaviour
    {
        private Pool<Enemy> _enemyPool;
        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(Pool<Enemy> pool, EnemyFactory enemyFactory)
        {
            _enemyPool = pool;
            _enemyFactory = enemyFactory;
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = _enemyFactory.Spawn();

                if(enemy != null) {
                    _enemyPool.AddToActiveBullets(enemy);
                }
            }
        }
    }
}

