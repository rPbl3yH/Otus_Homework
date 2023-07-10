using SaveLoad.ResourcesObject.Mediator;
using SaveLoad.Units.Mediator;
using Zenject;

namespace SaveLoad.GameManagement.Mediators
{
    public class MediatorsInstaller : MonoInstaller<MediatorsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ResourcesMediator>().FromNew().AsSingle();
            Container.Bind<UnitsMediator>().FromNew().AsSingle();
            Container.Bind<ResourcesObjectsMediator>().FromNew().AsSingle();
        }
    }
}