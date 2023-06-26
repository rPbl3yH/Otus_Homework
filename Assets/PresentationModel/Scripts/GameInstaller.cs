using Lessons.Architecture.PM;
using Zenject;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<CharacterInfo>().FromNew().AsSingle();
        Container.Bind<PlayerLevel>().FromNew().AsSingle();
        Container.Bind<UserInfo>().FromNew().AsSingle();
    }
}