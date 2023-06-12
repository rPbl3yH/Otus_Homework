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
    }
}
