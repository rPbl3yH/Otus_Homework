using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletPool : MonoBehaviour {
        public event Action<Bullet> OnBulletAdded;
        public event Action<Bullet> OnBulletRemoved;

        [SerializeField] private int _initialCount = 50;
        [SerializeField] private BulletFactory _bulletFactory;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _container;
        [SerializeField] private LevelBounds _levelBounds;

        private readonly Queue<Bullet> _bulletPool = new();
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _bulletCache = new();

        private void Awake() {
            for (var i = 0; i < _initialCount; i++) {
                var bullet = _bulletFactory.Create(_worldTransform);
                _bulletPool.Enqueue(bullet);
            }
        }

        private void FixedUpdate() {
            _bulletCache.Clear();
            _bulletCache.AddRange(_activeBullets);

            for (int i = 0, count = _bulletCache.Count; i < count; i++) {
                var bullet = _bulletCache[i];
                if (!_levelBounds.InBounds(bullet.transform.position)) {
                    Despawn(bullet);
                }
            }
        }

        public Bullet Spawn(BulletData bulletData) {
            if (_bulletPool.TryDequeue(out var bullet)) {
                bullet.transform.SetParent(_worldTransform);
                _bulletFactory.SetupBullet(bullet, bulletData);
            }
            else {
                bullet = _bulletFactory.Create(bulletData, _worldTransform);
            }

            AddToActiveBullets(bullet);

            return bullet;
        }

        public void Despawn(Bullet bullet) {
            if (_activeBullets.Remove(bullet)) {
                bullet.transform.SetParent(_container);
                _bulletPool.Enqueue(bullet);
                OnBulletRemoved?.Invoke(bullet);
            }
        }

        private void AddToActiveBullets(Bullet bullet) {
            if (_activeBullets.Add(bullet)) {
                OnBulletAdded?.Invoke(bullet);
            }
        }
    }
}