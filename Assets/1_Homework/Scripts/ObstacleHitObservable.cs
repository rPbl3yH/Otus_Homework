public class ObstacleHitObservable : IHitObservable
{
    private GameManager _gameManager;

    public ObstacleHitObservable(GameManager gameManager) {
        _gameManager = gameManager;
    }

    void IHitObservable.OnHit() {
        _gameManager.FinishGame();
    }
}

public interface IHitObservable
{
    void OnHit();
}
