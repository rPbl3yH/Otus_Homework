using Newtonsoft.Json;
using SaveLoad.GameManagment;
using Services;

namespace SaveLoad.SaveSystem
{
    public abstract class GameMediator<TData, TService> : IGameMediator
    {
        protected virtual string DataKey
        {
            get { return typeof(TData).Name; }
        }

        [ServiceInject]
        private GameContext _gameContext;

        void IGameMediator.SetupData(GameRepository repository)
        {
            var service = _gameContext.GetService<TService>();

            if (repository.TryGetData(DataKey, out var json))
            {
                var data = JsonConvert.DeserializeObject<TData>(json);
                SetupFromData(service, data);
            }
            else
            {
                SetupByDefault(service);
            }
        }

        void IGameMediator.SaveData(GameRepository repository)
        {
            var service = _gameContext.GetService<TService>();
            var data = ConvertToData(service);
            var json = JsonConvert.SerializeObject(data);
            repository.SetData(DataKey, json);
        }

        protected abstract void SetupFromData(TService service, TData data);

        protected abstract void SetupByDefault(TService service);

        protected abstract TData ConvertToData(TService service);
    }
}