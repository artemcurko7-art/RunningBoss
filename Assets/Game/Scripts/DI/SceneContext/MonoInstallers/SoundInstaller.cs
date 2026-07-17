using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Music;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class SoundInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<SoundService>()
                .AsSingle();

            Container
                .Bind<BackgroundMusicService>()
                .AsSingle();
        }
    }
}