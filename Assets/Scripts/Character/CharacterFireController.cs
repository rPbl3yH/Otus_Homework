using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour {
        [SerializeField] private Character _character;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private FireInput _fireInput;
        private BulletLauncher _bulletLauncher;

        [Inject]
        public void Construct(BulletLauncher bulletLauncher) {
            _bulletLauncher = bulletLauncher;
        }

        private void OnEnable() {
            _fireInput.OnFired += OnFired;
        }

        private void OnDisable() {
            _fireInput.OnFired -= OnFired;            
        }

        private void OnFired() {
            Fire();
        }

        private void Fire() {
            var bulletData = new BulletData {
                IsPlayer = true,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _weaponComponent.Position,
                Velocity = _weaponComponent.Rotation * Vector3.up * _bulletConfig.Speed
            };

            _bulletLauncher.SpawnBullet(bulletData);
        }
    }
}
