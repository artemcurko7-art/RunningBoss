using Game.Scripts.MV.SkillPoint;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalSkillPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SkillPoint>()
                .AsSingle();
        }
    }
}