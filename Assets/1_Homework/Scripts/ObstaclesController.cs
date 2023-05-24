using UnityEngine;

public class ObstaclesController : MonoBehaviour, IGameStartListener, IGamePauseListener, IGameResumeListener, IGameFinishListener
{
    [SerializeField] private Obstacle[] _obstacles;

    void IGameStartListener.OnGameStarted() {
        EnableTriggers(true);
    }

    void IGamePauseListener.OnGamePaused() {
        EnableTriggers(false);
    }

    void IGameResumeListener.OnGameResumed() {
        EnableTriggers(true);
    }

    void IGameFinishListener.OnGameFinished() {
        EnableTriggers(false);
    }

    public void EnableTriggers(bool isEnabled) {
        foreach (var trigger in _obstacles) {
            trigger.Enable(isEnabled);
        }
    }
}
