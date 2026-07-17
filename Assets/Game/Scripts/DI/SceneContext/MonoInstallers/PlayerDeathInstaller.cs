using Game.Scripts.Player.Death;
using Game.Scripts.Service;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class PlayerDeathInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISubscriber>()
                .To<ProgressDeath>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<PlaybackSoundDeath>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<EffectorDeath>()
                .AsCached();
        }
    }
}