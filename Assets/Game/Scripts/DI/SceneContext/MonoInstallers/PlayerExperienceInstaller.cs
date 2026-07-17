using Game.Scripts.Player.Killed;
using Game.Scripts.Service;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class PlayerExperienceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISubscriber>()
                .To<ExperienceKilled>()
                .AsCached();
        }
    }
}