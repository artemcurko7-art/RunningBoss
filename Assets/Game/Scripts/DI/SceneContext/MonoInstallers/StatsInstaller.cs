using Game.Scripts.MVC.Stat;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class StatsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<StatsController>()
                .AsSingle();
        }
    }
}