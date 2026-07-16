using Zenject;

public class GamePausedInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<ISubscriber>()
            .To<GameplayGamePaused>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<BackgroundMusicGamePaused>()
            .AsCached();
    }
}