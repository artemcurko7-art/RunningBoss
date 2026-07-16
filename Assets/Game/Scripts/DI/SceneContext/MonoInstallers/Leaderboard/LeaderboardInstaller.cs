using Zenject;

public class LeaderboardInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<ISubscriber>()
            .To<AddingValueLevelLeaderboard>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<AddingValueKilledLeaderboard>()
            .AsCached();
    }
}