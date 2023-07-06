using SaveLoad.GameManagement.Listeners;
using SaveLoad.GameManagement.Mediators;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad.GameManagement
{
    public class SaveSystemInstaller : MonoBehaviour, IGameInitListener
    {
        private MediatorsInstaller _mediatorsInstaller;
        [ShowInInspector]
        private GameRepository _gameRepository;
        [ShowInInspector]
        private GameSaver _gameSaver;

        public void InitGame()
        {
            Install();
        }

        private void Install()
        {
            _gameRepository = new GameRepository();
            _mediatorsInstaller = new MediatorsInstaller();
            _mediatorsInstaller.Install();
            _gameSaver = new GameSaver(_mediatorsInstaller.GetMediators().ToArray(), _gameRepository);
        }
    }
}