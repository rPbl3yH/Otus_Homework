using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private Character _character; 
        [SerializeField] private BulletConfig _bulletConfig;
        
        public bool _fireRequired;
        private BulletService _bulletService;
        private GameManager _gameManager;
        private HitPointsComponent _hitPointsComponent;
        private WeaponComponent _weaponComponent;

        private void Awake() {
            _hitPointsComponent = _character.HitPointsComponent;
            _weaponComponent = _character.WeaponComponent;
        }

        [Inject]
        private void Construct(GameManager gameManager, BulletService bulletService) {
            _gameManager = gameManager;
            _bulletService = bulletService;
        }

        private void OnEnable()
        {
            _hitPointsComponent.OnDeath += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.OnDeath -= OnCharacterDeath;
        }

        private void FixedUpdate()
        {
            if (_fireRequired)
            {
                Fire();
                _fireRequired = false;
            }
        }

        private void OnCharacterDeath(GameObject gameObj) {
            _gameManager.FinishGame();
        }

        private void Fire()
        {
            var bulletData = new BulletData {
                IsPlayer = true,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _weaponComponent.Position,
                Velocity = _weaponComponent.Rotation * Vector3.up * _bulletConfig.Speed
            };

			_bulletService.SpawnBullet(bulletData);
        }
    }
}