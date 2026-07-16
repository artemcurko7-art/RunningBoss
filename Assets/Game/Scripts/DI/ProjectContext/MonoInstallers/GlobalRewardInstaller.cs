using Zenject;

public class GlobalRewardInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<ProgressAddingReward>()
            .AsSingle();
    }
}