using Game.Scripts.Menu.Game.Resumed;
using Game.Scripts.Service;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class GameResumedInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISubscriber>()
                .To<GameplayGameResumed>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<BackgroundMusicGameResumed>()
                .AsCached();
        }
    }
}