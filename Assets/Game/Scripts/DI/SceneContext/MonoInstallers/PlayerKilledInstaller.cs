using Game.Scripts.Player.Killed;
using Game.Scripts.Player.ProcessingDetection;
using Game.Scripts.Service;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class PlayerKilledInstaller : MonoInstaller
    {
        [SerializeField] private ProcessingDetected detected;

        public override void InstallBindings()
        {
            Container
                .Bind<IKilled>()
                .FromInstance(detected)
                .AsSingle();

            Container
                .Bind<ISubscriber>()
                .To<PlayerAnimationKilled>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<KilledProgress>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<QuestKilled>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<PlaybackSoundKilled>()
                .AsCached();
        }
    }
}