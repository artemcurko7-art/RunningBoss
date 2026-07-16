using Zenject;

public class GlobalSkillPointInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<SkillPoint>()
            .AsSingle();
    }
}