using Zenject;

namespace SaveLoad.GameManagement
{
    public class SaveSystemInstaller : MonoInstaller<SaveSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameRepository>().FromNew().AsSingle();
            Container.Bind<GameSaver>().FromNew().AsSingle();
        }
    }
}