using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemiesObserver : MonoBehaviour
    {
        [SerializeField] private BulletConfig _bulletConfig;
        private BulletLauncher _bulletService;
        private Pool<Enemy> _enemyPool;

        [Inject]
        public void Construct(Pool<Enemy> pool, BulletLauncher bulletService) {
            _enemyPool = pool;
            _bulletService = bulletService;
        }

        private void Start() {
            _enemyPool.OnActiveItemAdded += OnActiveBulletAdded;
            _enemyPool.OnActiveItemRemoved += OnActiveBulletRemoved;
        }

        private void OnDestroy() {
            _enemyPool.OnActiveItemAdded -= OnActiveBulletAdded;
            _enemyPool.OnActiveItemRemoved -= OnActiveBulletRemoved;
        }

        private void OnActiveBulletRemoved(Enemy enemy) {
            enemy.HitPointsComponent.OnDeath -= OnDestroyed;
            enemy.EnemyAttackAgent.OnFire -= OnFire;
        }

        private void OnActiveBulletAdded(Enemy enemy) {
            enemy.HitPointsComponent.OnDeath += OnDestroyed;
            enemy.EnemyAttackAgent.OnFire += OnFire;
        }

        private void OnFire(GameObject gameObj, Vector2 position, Vector2 direction) {
            _bulletService.SpawnBullet(new BulletData {
                IsPlayer = false,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = position,
                Velocity = direction * 2.0f
            });
        }

        private void OnDestroyed(GameObject gameObj) {
            var enemy = gameObj.GetComponent<Enemy>();
            _enemyPool.Despawn(enemy);
        }
    }
}
