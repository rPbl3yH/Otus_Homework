using Homeworks.SaveLoad;
using SaveLoad.GameManagement;
using SaveLoad.GameManagement.Listeners;
using UnityEngine;

namespace SaveLoad.ResourcesObject
{
    public class ResourceObjectsServiceInstaller : MonoBehaviour, IGameInitListener
    {
        [SerializeField] private ResourceObject[] _resourceObjects;

        private ResourcesObjectService _resourcesObjectService;

        public void InitGame()
        {
            _resourcesObjectService = new ResourcesObjectService(_resourceObjects);
        }
    }
}