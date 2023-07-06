namespace SaveLoad.GameManagement
{
    public interface IGameMediator
    {
        void SetupData(GameRepository repository);

        void SaveData(GameRepository repository);
    }
}