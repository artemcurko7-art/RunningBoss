using Zenject;

public class SoundInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<SoundService>().
            AsSingle();
        
        Container.
            Bind<BackgroundMusicService>().
            AsSingle();
    }
}