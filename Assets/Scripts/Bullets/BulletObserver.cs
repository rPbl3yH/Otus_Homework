using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletObserver : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;

        private void OnEnable() {
            _bulletPool.OnBulletAdded += OnBulletAdded;
            _bulletPool.OnBulletRemoved += OnBulletRemoved;
        }

        private void OnBulletRemoved(Bullet bullet) {
            bullet.OnCollisionEntered -= OnBulletCollision;
        }

        private void OnBulletAdded(Bullet bullet) {
            bullet.OnCollisionEntered += OnBulletCollision;
        }

        public void CreateBullet(BulletData bulletData)
        {
            _bulletPool.Spawn(bulletData);
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            _bulletPool.Despawn(bullet);
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