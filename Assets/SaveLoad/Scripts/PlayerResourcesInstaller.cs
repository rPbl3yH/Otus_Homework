using SaveLoad.GameManagement;
using SaveLoad.GameManagement.Listeners;
using UnityEngine;
using Zenject;

namespace SaveLoad.Scripts
{
    public class PlayerResourcesInstaller : MonoInstaller<PlayerResourcesInstaller>
    {
        [SerializeField] private PlayerResources _playerResources;

        public override void InstallBindings()
        {
            Container.Bind<PlayerResources>().FromInstance(_playerResources);
        }
    }
}