using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int initialCount = 50;
        
        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private BulletFactory _bulletFactory;

        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();
        
        private void Awake() //pool logic
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = _bulletFactory.Create(worldTransform); 
                this.m_bulletPool.Enqueue(bullet);
            }
        }
        
        private void FixedUpdate()
        {
            this.m_cache.Clear();
            this.m_cache.AddRange(this.m_activeBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++)
            {
                var bullet = this.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void CreateBullet(BulletData bulletData)
        {
            if (this.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = _bulletFactory.Create(bulletData, worldTransform);
            }
            
            if (this.m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (this.m_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= this.OnBulletCollision;
                bullet.transform.SetParent(this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }
    }
    
    public struct BulletData
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Color Color;
        public int PhysicsLayer;
        public int Damage;
        public bool IsPlayer;
    }
}