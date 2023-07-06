using System.Collections.Generic;
using System.Linq;
using SaveLoad.GameManagement.Listeners;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad.GameManagement
{
    public class GameManager : MonoBehaviour
    {

        private List<IGameListener> _listeners = new List<IGameListener>();
        
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