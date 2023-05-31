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

        private void OnEnable()
        {
            this.character.GetComponent<HitPointsComponent>().OnDeath += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this.character.GetComponent<HitPointsComponent>().OnDeath -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();

        private void FixedUpdate()
        {
            if (this._fireRequired)
            {
                this.OnFlyBullet();
                this._fireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            var weapon = this.character.GetComponent<WeaponComponent>();
            _bulletService.CreateBullet(new BulletData
            {
                IsPlayer = true,
                PhysicsLayer = (int) this._bulletConfig.PhysicsLayer,
                Color = this._bulletConfig.Color,
                Damage = this._bulletConfig.Damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * this._bulletConfig.Speed
            });
        }
    }
}