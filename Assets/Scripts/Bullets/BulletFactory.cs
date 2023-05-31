using UnityEngine;

namespace ShootEmUp
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;

        public Bullet Create(Transform parentPoint) {
            var bullet = Instantiate(_bulletPrefab, parentPoint);
            return bullet;
        }

        public Bullet Create(BulletData bulletData, Transform parentPoint) {
            var bullet = Instantiate(_bulletPrefab, parentPoint);
            SetupBullet(bullet, bulletData);
            return bullet;
        }

        public void SetupBullet(Bullet bullet, BulletData bulletData) {
            bullet.SetColor(bulletData.Color);
            bullet.SetDamage(bulletData.Damage);
            bullet.SetPhysicsLayer(bulletData.PhysicsLayer);
            bullet.SetPosition(bulletData.Position);
            bullet.SetVelocity(bulletData.Velocity);
            bullet.SetTeam(bulletData.IsPlayer);
        }
    }
}