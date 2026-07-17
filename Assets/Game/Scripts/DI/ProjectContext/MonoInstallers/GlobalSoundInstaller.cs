using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Music;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
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
}