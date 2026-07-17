using Game.Scripts.Leaderboard;
using Game.Scripts.Service;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
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
}