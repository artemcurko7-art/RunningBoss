using UnityEngine;
using YG;
using Zenject;

public class SelectorInstaller : MonoInstaller
{
    [SerializeField] private Transform _mobileContainer;
    [SerializeField] private Transform _desktopContainer;

    private Transform _currentContainer;
    
    public override void InstallBindings()
    {
        _currentContainer = YG2.envir.isMobile ? _mobileContainer : _desktopContainer;

        Container
            .BindInterfacesAndSelfTo<SelectorAnimalViewService>()
            .AsSingle()
            .WithArguments(_currentContainer);
        
        Container
            .BindInterfacesAndSelfTo<SelectorItemViewService>()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<SelectorUIUpdater>()
            .AsSingle();
        
        Container
            .Bind<SelectorItemUpdater>()
            .AsSingle();
        
        Container
            .Bind<SelectorStorageData>()
            .AsSingle();
        
        Container
            .BindInterfacesTo<SelectorItemController>()
            .AsSingle()
            .NonLazy();
    }
}