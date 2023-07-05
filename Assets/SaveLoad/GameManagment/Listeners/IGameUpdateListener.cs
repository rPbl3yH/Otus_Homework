namespace SaveLoad.GameManagment
{
    public interface IGameUpdateListener : IGameListener
    {
        void OnUpdate(float deltaTime);
    }
}