using Game.Scripts.Player.Movement;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class PlayerMoverInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<MoverForward>()
                .AsSingle();
        }
    }
}