using Game.Scripts.MV.Progress;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalRewardInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ProgressAddingReward>()
                .AsSingle();
        }
    }
}