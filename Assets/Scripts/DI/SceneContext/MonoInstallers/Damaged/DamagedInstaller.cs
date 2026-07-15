using UnityEngine;
using Zenject;

public class DamagedInstaller : MonoInstaller
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Material _material;
    
    public override void InstallBindings()
    {
        Container.
            Bind<ISubscriber>().
            To<SoundDamaged>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<SlowingSpeedDamaged>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<ChangingMaterialDamaged>().
            AsCached().
            WithArguments(_material);
        
        Container.
            Bind<ISubscriber>().
            To<ShakingCameraDamaged>().
            AsCached().
            WithArguments(_mainCamera);
    }
}