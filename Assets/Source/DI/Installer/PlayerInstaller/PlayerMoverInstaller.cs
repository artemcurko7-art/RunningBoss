using Zenject;

public class PlayerMoverInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<MoverForward>().
            AsSingle();
        
        Container.
            Bind<MoverHorizontal>().
            AsSingle();
    }
}
