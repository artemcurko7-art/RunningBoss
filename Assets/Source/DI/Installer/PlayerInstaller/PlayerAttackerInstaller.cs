using UnityEngine;
using Zenject;

public class PlayerAttackerInstaller : MonoInstaller
{
    [SerializeField] private ProcessingDetection _detection;
    
    public override void InstallBindings()
    {
        Container.
            Bind<IAttacker>().
            FromInstance(_detection).
            AsSingle();
        
        Container.
            Bind<PlayerAnimationAttacker>().
            AsSingle();
    }
}