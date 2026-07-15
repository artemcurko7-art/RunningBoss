using Zenject;

public class GlobalServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<ItemViewService>().
            AsSingle();
        
        // Container.
        //     Bind<ComplexityLevelService>().
        //     AsSingle().
        //     NonLazy(); 
    }
}
