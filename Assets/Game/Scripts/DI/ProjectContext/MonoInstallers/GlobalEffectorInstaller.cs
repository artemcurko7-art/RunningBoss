using Zenject;

public class GlobalEffectorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<EffectorData>()
            .AsSingle()
            .NonLazy();
    }
}