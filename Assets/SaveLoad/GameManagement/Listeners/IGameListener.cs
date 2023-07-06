namespace SaveLoad.GameManagement.Listeners
{
    public interface IGameListener
    {
        
    }

    public interface IGameInitListener : IGameListener
    {
        void InitGame();
    }

    public interface IGameLoadListener : IGameListener
    {
        void LoadGame();
    }

    public interface IGameStartListener : IGameListener
    {
        void StartGame();
    }

    public interface IGameUpdateListener : IGameListener
    {
        void UpdateGame();
    }
}