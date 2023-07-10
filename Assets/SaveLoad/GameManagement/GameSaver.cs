using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveLoad.GameManagement
{
    public class GameSaver
    {
        private readonly IGameMediator[] _gameMediators;
        private readonly GameRepository _gameRepository;

        [Inject]
        public GameSaver(IGameMediator[] gameMediators, GameRepository gameRepository)
        {
            _gameMediators = gameMediators;
            _gameRepository = gameRepository;
        }

        [ShowInInspector]
        public void Save()
        {
            Debug.Log("Game mediators = " + _gameMediators.Length);
            foreach (var gameMediator in _gameMediators)
            {
                gameMediator.SaveData(_gameRepository);
            }
            
            _gameRepository.SaveState();
            Debug.Log("Save");
        }

        [ShowInInspector]
        public void Load()
        {
            _gameRepository.LoadState();
            
            foreach (var gameMediator in _gameMediators)
            {
                gameMediator.SetupData(_gameRepository);    
            }
            
            Debug.Log("Load");
        }
    }
}