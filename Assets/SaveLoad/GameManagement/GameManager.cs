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
    }
}