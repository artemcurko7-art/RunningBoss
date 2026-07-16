using Zenject;

public class GlobalLeaderboardInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<LeaderboardData>()
            .AsSingle()
            .NonLazy();
        
        Container
            .BindInterfacesAndSelfTo<TimerLeaderboard>()
            .AsCached();
    }
}