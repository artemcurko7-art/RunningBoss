using Game.Scripts.Player.ProcessingDetection;
using Game.Scripts.Service;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class ProcessingDetectedInstaller : MonoInstaller
    {
        [SerializeField] private ProcessingDetected _processingDetected;

        public override void InstallBindings()
        {
            Container
                .Bind<IProcessingDetected>()
                .FromInstance(_processingDetected)
                .AsSingle();

            Container
                .Bind<ISubscriber>()
                .To<RagdollOperationsProcessDetection>()
                .AsCached();

            Container
                .Bind<ISubscriber>()
                .To<EffectorProcessDetection>()
                .AsCached();
        }
    }
}