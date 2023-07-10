using Homeworks.SaveLoad;
using UnityEngine;
using Zenject;

namespace SaveLoad.ResourcesObject
{
    public class ResourceObjectsServiceInstaller : MonoInstaller<ResourceObjectsServiceInstaller>
    {
        [SerializeField] private ResourceObject[] _resourceObjects;

        public override void InstallBindings()
        {
            Container.Bind<ResourcesObjectService>().FromNew().AsSingle().WithArguments(_resourceObjects);
        }
    }
}