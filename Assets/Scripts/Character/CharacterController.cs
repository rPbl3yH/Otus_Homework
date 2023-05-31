using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject character; 
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletService _bulletService;
        [SerializeField] private BulletConfig _bulletConfig;
        
        public bool _fireRequired;
        private HitPointsComponent _hitPointsComponent;

        private void Awake() {
            _hitPointsComponent = character.GetComponent<HitPointsComponent>();
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

        private void OnCharacterDeath(GameObject _) {
            gameManager.FinishGame();
        }

        private void Fire()
        {
            var weapon = character.GetComponent<WeaponComponent>();
            _bulletService.CreateBullet(new BulletData
            {
                IsPlayer = true,
                PhysicsLayer = (int) _bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * _bulletConfig.Speed
            });
        }
    }
}