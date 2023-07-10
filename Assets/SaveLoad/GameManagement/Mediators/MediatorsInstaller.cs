using SaveLoad.ResourcesObject.Mediator;
using SaveLoad.Units.Mediator;
using Zenject;

namespace SaveLoad.GameManagement.Mediators
{
    public class MediatorsInstaller : MonoInstaller<MediatorsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameMediator>().To<ResourcesMediator>().FromNew().AsSingle();
            Container.Bind<IGameMediator>().To<UnitsMediator>().FromNew().AsSingle();
            Container.Bind<IGameMediator>().To<ResourcesObjectMediator>().FromNew().AsSingle();
        }
    }
}