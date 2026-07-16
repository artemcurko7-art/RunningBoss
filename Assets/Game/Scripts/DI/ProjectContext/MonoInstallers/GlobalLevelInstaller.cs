using Zenject;

public class GlobalLevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesTo<GameLevel>()
            .AsSingle();
        
        Container
            .BindInterfacesAndSelfTo<LocationLevel>()
            .AsSingle();
    }
}