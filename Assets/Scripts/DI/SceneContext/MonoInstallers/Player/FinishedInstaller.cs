using UnityEngine;
using YG;
using Zenject;

public class FinishedInstaller : MonoInstaller
{
    [SerializeField] private RectTransform _mobileContainer;
    [SerializeField] private RectTransform _desktopContainer;
    [SerializeField] private Transform _spawnFirework;

    private RectTransform _currentContainer;
    
    public override void InstallBindings()
    {
        _currentContainer = YG2.envir.isMobile ? _mobileContainer : _desktopContainer;
        
        Container.
            Bind<ISubscriber>().
            To<CreationItemViewFinished>().
            AsCached().
            WithArguments(_currentContainer);
        
        Container.
            Bind<ISubscriber>().
            To<RaisingLocationLevelFinished>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<AddingGameExperienceFinished>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<PlaybackSoundFinished>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<FireworkEffectorFinished>().
            AsCached().
            WithArguments(_spawnFirework);
        
        Container.
            Bind<ISubscriber>().
            To<SwitchingToCardFinished>().
            AsCached();
    }
}