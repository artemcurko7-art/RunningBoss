using Game.Scripts.Leaderboard;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
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
}