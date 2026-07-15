using Zenject;

public class GameResumedInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<ISubscriber>().
            To<GameplayGameResumed>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<BackgroundMusicGameResumed>().
            AsCached();
    }
}