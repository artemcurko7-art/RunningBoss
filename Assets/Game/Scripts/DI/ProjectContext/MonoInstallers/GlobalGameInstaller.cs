using Game.Scripts.Menu.Game;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Menu.Game.Game>()
                .AsSingle();
        }
    }
}