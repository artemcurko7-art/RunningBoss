using Zenject;

public class GlobalProgressInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            BindInterfacesAndSelfTo<ProgressData>().
            AsSingle();
    }
}