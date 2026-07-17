using Game.Scripts.MV.Progress.Data;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalProgressInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ProgressData>()
                .AsSingle();
        }
    }
}