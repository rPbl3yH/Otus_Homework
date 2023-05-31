using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletPool : MonoBehaviour {
        public event Action<Bullet> OnBulletAdded;
        public event Action<Bullet> OnBulletRemoved;

        [SerializeField] private int initialCount = 50;
        [SerializeField] private BulletFactory _bulletFactory;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Transform container;
        [SerializeField] private LevelBounds levelBounds;


        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();

        private void Awake() {
            for (var i = 0; i < this.initialCount; i++) {
                var bullet = _bulletFactory.Create(worldTransform);
                this.m_bulletPool.Enqueue(bullet);
            }
        }

        private void FixedUpdate() {
            this.m_cache.Clear();
            this.m_cache.AddRange(this.m_activeBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++) {
                var bullet = this.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position)) {
                    Despawn(bullet);
                }
            }
        }

        public Bullet Spawn(BulletData bulletData) {
            if (this.m_bulletPool.TryDequeue(out var bullet)) {
                bullet.transform.SetParent(this.worldTransform);
                _bulletFactory.SetupBullet(bullet, bulletData);
            }
            else {
                bullet = _bulletFactory.Create(bulletData, worldTransform);
            }

            AddToActiveBullets(bullet);

            return bullet;
        }

        public void Despawn(Bullet bullet) {
            if (this.m_activeBullets.Remove(bullet)) {
                bullet.transform.SetParent(this.container);
                this.m_bulletPool.Enqueue(bullet);
                OnBulletRemoved?.Invoke(bullet);
            }
        }

        private void AddToActiveBullets(Bullet bullet) {
            if (m_activeBullets.Add(bullet)) {
                OnBulletAdded?.Invoke(bullet);
            }
        }
    }
}