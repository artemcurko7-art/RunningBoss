using Zenject;

public class StatsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<StatsController>().
            AsSingle();
    }
}