using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletCollisionController : MonoBehaviour
    {
        private Pool<Bullet> _bulletPool;
        private LevelBounds _levelBounds;
        private HashSet<Bullet> _bullets = new();
        private readonly List<Bullet> _bulletCache = new();

        [Inject]
        public void Construct(Pool<Bullet> pool, LevelBounds levelBounds) {
            _bulletPool = pool;
            _levelBounds = levelBounds;
        }

        private void Start() {
            _bulletPool.OnActiveItemAdded += OnBulletAdded;
            _bulletPool.OnActiveItemRemoved += OnBulletRemoved;
        }

        private void OnDestroy() {
            _bulletPool.OnActiveItemAdded -= OnBulletAdded;
            _bulletPool.OnActiveItemRemoved -= OnBulletRemoved;
        }

        private void FixedUpdate() {
            _bulletCache.Clear();
            _bulletCache.AddRange(_bullets);

            for (int i = 0, count = _bulletCache.Count; i < count; i++) {
                var bullet = _bulletCache[i];
                if (!_levelBounds.InBounds(bullet.transform.position)) {
                    _bulletPool.Despawn(bullet);
                }
            }
        }

        private void OnBulletAdded(Bullet bullet) {
            _bullets.Add(bullet);
            bullet.OnCollisionEntered += OnBulletCollision;
        }

        private void OnBulletRemoved(Bullet bullet) {
            _bullets.Remove(bullet);
            bullet.OnCollisionEntered -= OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision) {
            bullet.OnCollisionEntered -= OnBulletCollision;
            DealDamage(bullet, collision.gameObject);
            _bulletPool.Despawn(bullet);
        }

        private void DealDamage(Bullet bullet, GameObject other) {
            if (!other.TryGetComponent(out TeamComponent team)) {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer) {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints)) {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }
    }
}
