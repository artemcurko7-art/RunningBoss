using Zenject;

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