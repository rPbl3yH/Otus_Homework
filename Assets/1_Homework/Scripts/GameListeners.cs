public class GameListeners
{
}

public interface IGameListener
{
}

public interface IGameStartListener : IGameListener
{
    void OnGameStarted();
}

public interface IGameFinishListener : IGameListener
{
    void OnGameFinish();
}

public interface IGameUpdateListener : IGameListener
{
    void OnUpdate(float deltaTime);
}
