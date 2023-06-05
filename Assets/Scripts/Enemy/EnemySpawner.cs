using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
	public class EnemySpawner : MonoBehaviour
    {
        private Pool<Enemy> _enemyPool;

        [SerializeField] private EnemyFactory _enemyFactory;


        public void Construct(Pool<Enemy> pool)
        {
            _enemyPool = pool;
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

