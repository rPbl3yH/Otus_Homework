using System;
using System.Collections.Generic;
using System.Linq;
using SaveLoad.GameManagement.Listeners;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveLoad.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [Inject]
        [ShowInInspector]
        private GameRepository _gameRepository;
        
        [Inject]
        [ShowInInspector]
        private GameSaver _gameSaver;

        private List<IGameListener> _listeners = new List<IGameListener>();

        private void Awake()
        {
            ServiceLocator.Clear();
        }

        [ShowInInspector]
        public void StartGame()
        {
            _listeners = GetComponentsInChildren<IGameListener>(true).ToList();
            InitGame();
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
    }
}