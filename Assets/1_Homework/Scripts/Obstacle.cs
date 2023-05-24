using UnityEngine;

public class Obstacle : MonoBehaviour, IGameStartListener, IGamePauseListener, IGameResumeListener, IGameFinishListener
{
    private IHitObservable _hitObservable;

    void IGameStartListener.OnGameStarted() {
        enabled = true;
    }

    void IGamePauseListener.OnGamePaused() {
        enabled = false;
    }

    void IGameResumeListener.OnGameResumed() {
        enabled = true;
    }

    void IGameFinishListener.OnGameFinished() {
        enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody) {
            if (other.attachedRigidbody.GetComponent<MoveComponent>()) {
                _hitObservable.OnHit();
            }
        }
    }

    public void Init(IHitObservable hitObservable) {
        _hitObservable = hitObservable;
    }
}
