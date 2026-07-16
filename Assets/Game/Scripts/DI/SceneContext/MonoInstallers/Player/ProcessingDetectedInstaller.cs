using UnityEngine;
using Zenject;

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