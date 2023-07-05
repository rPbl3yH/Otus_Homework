namespace SaveLoad.SaveSystem
{
    public interface IGameMediator
    {
        void SetupData(GameRepository repository);

        void SaveData(GameRepository repository);
    }
}