using System.Collections.Generic;
using System.Linq;
using SaveLoad.GameManagement.Listeners;
using SaveLoad.GameManagement.Mediators;
using SaveLoad.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerResources _playerResources;

        private MediatorInstaller _mediatorInstaller;
        [ShowInInspector]
        private GameRepository _gameRepository;
        [ShowInInspector]
        private GameSaver _gameSaver;
        
        private List<IGameListener> _listeners = new List<IGameListener>();
        
        [ShowInInspector]
        public void StartGame()
        {
            GameContext.AddService(_playerResources);
            _listeners = GetComponentsInChildren<IGameListener>(true).ToList();
            InitGame();
            
            _gameRepository = new GameRepository();
            _mediatorInstaller = new MediatorInstaller();
            _mediatorInstaller.Install();
            _gameSaver = new GameSaver(_mediatorInstaller.GetMediators().ToArray(), _gameRepository);
        }

        public void InitGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IGameInitListener initListener)
                {
                    initListener.InitGame();
                }
            }
        }

        public void LoadGame()
        {
            
        }

        public void SaveGame()
        {
            
        }
    }
}