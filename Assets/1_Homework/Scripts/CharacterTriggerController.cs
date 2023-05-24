using UnityEngine;

public class CharacterTriggerController : MonoBehaviour, IGameStartListener
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private CharacterTriggerTracker _triggerTracker;

    public void OnGameStarted() {
        _triggerTracker.OnTriggerEntered += OnTriggerEntered;
    }

    private void OnTriggerEntered(Collider collider) {
        if (collider.GetComponent<Obstacle>()) {
            _gameManager.FinishGame();
        }
    }
}
