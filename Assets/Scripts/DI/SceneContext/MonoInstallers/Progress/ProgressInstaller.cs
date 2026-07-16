using UnityEngine;
using YG;
using Zenject;

public class ProgressInstaller : MonoInstaller
{
    [SerializeField] private ProgressView _view;
    [SerializeField] private RectTransform _mobileContainer;
    [SerializeField] private RectTransform _desktopContainer;
    
    private RectTransform _currentContainer;

    public override void InstallBindings()
    {
        _currentContainer = YG2.envir.isMobile ? _mobileContainer : _desktopContainer;
        
        Container.
            Bind<ProgressService>().
            AsSingle().
            WithArguments(_currentContainer).
            NonLazy();
        
        Container.
            Bind<ProgressViewFactory>().
            AsSingle();

        Container.
            Bind<AddingCoinProgress>().
            AsSingle();
        
        Container.
            Bind<ProgressView>().
            FromInstance(_view).
            AsSingle();
    }
}