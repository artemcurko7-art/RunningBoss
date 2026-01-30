using UnityEngine;
using Zenject;

public class PlayerDetectionInstaller : MonoInstaller
{
    [SerializeField] private ProcessingDetection _detection;
    
    public override void InstallBindings()
    {
        Container.
            Bind<IProcessingDetection>().
            FromInstance(_detection).
            AsSingle();
        
        Container.
            Bind<PlayerRagdollOperations>().
            AsSingle();
    }
}
