using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterDeathController : MonoBehaviour {

        [SerializeField] private HitPointsComponent _hitPointsComponent;
        private GameManager _gameManager;

        [Inject]
        public void Construct(GameManager gameManager) {
            _gameManager = gameManager;
        }

        private void OnEnable() {
            _hitPointsComponent.OnDeath += OnCharacterDeath;
        }

        private void OnDisable() {
            _hitPointsComponent.OnDeath -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject gameObj) {
            _gameManager.FinishGame();
        }

    }
}
