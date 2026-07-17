using Game.Scripts.MV.Level.GameLevel.Level;
using Game.Scripts.MV.Level.LocationLevel;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<GameLevel>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<LocationLevel>()
                .AsSingle();
        }
    }
}