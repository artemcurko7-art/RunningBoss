using Zenject;

public class PoolMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<UnitPool>().
            AsSingle();
        
        Container.
            Bind<MapPool>().
            AsSingle();
        
        Container.
            Bind<SettingPosition>().
            AsSingle();
    }
}