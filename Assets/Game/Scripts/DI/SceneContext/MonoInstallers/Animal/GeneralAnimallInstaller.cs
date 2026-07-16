using Zenject;

public class GeneralAnimallInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<AnimalService>()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<AnimalViewFactory>()
            .AsSingle();
    }
}