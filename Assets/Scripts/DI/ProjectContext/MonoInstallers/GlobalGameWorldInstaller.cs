using Zenject;

public class GlobalGameWorldInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<GameWorldData>().
            AsSingle();
    }
}