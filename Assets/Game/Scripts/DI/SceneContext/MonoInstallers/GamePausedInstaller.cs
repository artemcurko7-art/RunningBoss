using Game.Scripts.Menu.Game.Paused;
using Game.Scripts.Service;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class GamePausedInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISubscriber>()
                .To<GameplayGamePaused>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<BackgroundMusicGamePaused>()
                .AsCached();
        }
    }
}