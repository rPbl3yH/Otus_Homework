using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public sealed class EnemiesObserver : MonoBehaviour
    {
        private BulletService _bulletService;
        private Pool<Enemy> _enemyPool;

        [Inject]
        public void Construct(Pool<Enemy> pool, BulletService bulletService)
        {
            _enemyPool = pool;
            _bulletService = bulletService;
        }

        private void Start()
        {
            _enemyPool.OnActiveBulletAdded += OnActiveBulletAdded;
            _enemyPool.OnActiveBulletRemoved += OnActiveBulletRemoved;
        }

        private void OnDestroy()
        {
            _enemyPool.OnActiveBulletAdded -= OnActiveBulletAdded;
            _enemyPool.OnActiveBulletRemoved -= OnActiveBulletRemoved;
        }

        private void OnActiveBulletRemoved(Enemy enemy)
        {
            enemy.HitPointsComponent.OnDeath -= OnDestroyed;
            enemy.EnemyAttackAgent.OnFire -= OnFire;
        }

        private void OnActiveBulletAdded(Enemy enemy)
        {
            enemy.HitPointsComponent.OnDeath += OnDestroyed;
            enemy.EnemyAttackAgent.OnFire += OnFire;
        }

        private void OnFire(GameObject gameObj, Vector2 position, Vector2 direction)
        {
            _bulletService.SpawnBullet(new BulletData
            {
                IsPlayer = false,
                PhysicsLayer = (int)PhysicsLayer.ENEMY,
                Color = Color.red,
                Damage = 1,
                Position = position,
                Velocity = direction * 2.0f
            });
        }

        private void OnDestroyed(GameObject gameObj)
        {
            var enemy = gameObj.GetComponent<Enemy>();
            _enemyPool.Despawn(enemy);
        }
    }
}

