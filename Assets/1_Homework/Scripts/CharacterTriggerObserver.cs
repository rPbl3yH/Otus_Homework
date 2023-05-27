using UnityEngine;

public class CharacterTriggerObserver : MonoBehaviour, IGameStartListener
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TriggerComponent _triggerTracker;

    public void OnGameStarted() {
        _triggerTracker.OnTriggerEntered += OnTriggerEntered;
    }

    private void OnTriggerEntered(Collider collider) {
        if (collider.GetComponent<Obstacle>()) {
            _gameManager.FinishGame();
        }
    }
}
