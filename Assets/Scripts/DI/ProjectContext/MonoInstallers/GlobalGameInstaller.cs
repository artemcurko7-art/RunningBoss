using Zenject;

public class GlobalGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            BindInterfacesAndSelfTo<Game>().
            AsSingle();
    }
}
