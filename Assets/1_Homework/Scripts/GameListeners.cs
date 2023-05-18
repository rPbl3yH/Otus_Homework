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
    void OnGameFinished();
}

public interface IGamePauseListener : IGameListener
{
    void OnGamePaused();
}

public interface IGameResumeListener : IGameListener
{
    void OnGameResumed();
}

public interface IGameUpdateListener : IGameListener
{
    void OnUpdate(float deltaTime);
}

public interface IGameLateUpdateListener : IGameListener
{
    void OnLateUpdate(float deltaTime);
}
