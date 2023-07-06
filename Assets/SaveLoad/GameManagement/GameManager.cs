using System.Collections.Generic;
using Homeworks.SaveLoad.SaveSystem;
using SaveLoad.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerResources _playerResources;

        [ShowInInspector]
        private List<IGameMediator> _mediators = new List<IGameMediator>();
        [ShowInInspector]
        private GameRepository _gameRepository;
        [ShowInInspector]
        private GameSaver _gameSaver;
        
        [ShowInInspector]
        public void StartGame()
        {
            GameContext.AddService(_playerResources);
            _gameRepository = new GameRepository();
            _mediators.Add(new ResourcesMediator());
            _gameSaver = new GameSaver(_mediators.ToArray(), _gameRepository);
        }

        public void LoadGame()
        {
            
        }

        public void SaveGame()
        {
            
        }
    }
}