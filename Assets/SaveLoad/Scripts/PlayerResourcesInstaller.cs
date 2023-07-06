using SaveLoad.GameManagement;
using SaveLoad.GameManagement.Listeners;
using UnityEngine;

namespace SaveLoad.Scripts
{
    public class PlayerResourcesInstaller : MonoBehaviour, IGameInitListener
    {
        [SerializeField] private PlayerResources _playerResources;
        
        public void InitGame()
        {
            GameContext.AddService(_playerResources);            
        }
    }
}