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

        public Bullet Create(in BulletData bulletData, Transform parentPoint) {
            var bullet = Instantiate(_bulletPrefab, parentPoint);
            bullet.SetColor(bulletData.Color);
            bullet.SetDamage(bulletData.Damage);
            bullet.SetPhysicsLayer(bulletData.PhysicsLayer);
            bullet.SetPosition(bulletData.Position);
            bullet.SetVelocity(bulletData.Velocity);
            bullet.SetTeam(bulletData.IsPlayer);

            return bullet;
        }
    }
}