using UnityEngine;

namespace ShootEmUp
{

    public sealed class BulletService : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;

        public void CreateBullet(BulletData bulletData) {
            _bulletPool.Spawn(bulletData);
        }
    }
}
