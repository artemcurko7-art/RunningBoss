using Zenject;

public class GlobalSoundInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<SoundData>()
            .AsSingle();
        
        Container
            .Bind<BackgroundMusicData>()
            .AsSingle();
    }
}