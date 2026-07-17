using Game.Scripts.Effector;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalEffectorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EffectorData>()
                .AsSingle()
                .NonLazy();
        }
    }
}