using UnityEngine;
using YG;
using Zenject;

public class GameEndedInstaller : MonoInstaller
{
    [SerializeField] private DisplayGameEnded _mobileDisplay;
    [SerializeField] private DisplayGameEnded _desktopDisplay;
    [SerializeField] private GameObject[] _mobileObjects;
    [SerializeField] private GameObject[] _desktopObjects;
    [SerializeField] private RectTransform _mobileAnimalContainer;
    [SerializeField] private RectTransform _desktopAnimalContainer;
    [SerializeField] private DisplayLevelUpped _mobileDisplayLevelUpped;
    [SerializeField] private DisplayLevelUpped _desktopDisplayLevelUpped;
    
    private DisplayGameEnded _currentDisplay;
    private DisplayLevelUpped _currentDisplayLevelUpped;
    private RectTransform _currentAnimalContainer;
    private GameObject[] _currentObjects;
    
    public override void InstallBindings()
    {
        _currentDisplay = YG2.envir.isMobile ? _mobileDisplay : _desktopDisplay;
        _currentDisplayLevelUpped = YG2.envir.isMobile ? _mobileDisplayLevelUpped : _desktopDisplayLevelUpped;
        _currentAnimalContainer = YG2.envir.isMobile ? _mobileAnimalContainer : _desktopAnimalContainer;
        _currentObjects = YG2.envir.isMobile ? _mobileObjects : _desktopObjects;
        
        Container
            .BindInterfacesAndSelfTo<GamePoint>()
            .AsSingle();
        
        Container
            .BindInterfacesTo<AddingCoinKilled>()
            .AsCached();
        
        Container
            .BindInterfacesTo<AddingCoinFinished>()
            .AsCached();
        
        Container
            .BindInterfacesTo<AddingCoinLevelUpped>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<PausedGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<FinishedGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<DeathGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<ShowingDisplayGameEnded>()
            .AsCached()
            .WithArguments(_currentDisplay, _currentDisplayLevelUpped);
        
        Container
            .Bind<ISubscriber>()
            .To<AddingCoinDistanceMapGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<AddingCoinInWalletGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<QuestDistanceMapGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<AddingCoinQuestGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<QuestCompletedLevelNotDeathGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<QuestLevelCompletedGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<CreationAnimalViewGameEnded>()
            .AsCached()
            .WithArguments(_currentAnimalContainer);
        
        Container
            .Bind<HandlerChangingLayer>()
            .AsSingle();
        
        Container
            .Bind<ISubscriber>()
            .To<ChangingAnimationAnimalViewGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<DisablingUIGameEnded>()
            .AsCached()
            .WithArguments(_currentObjects);
        
        Container
            .Bind<ISubscriber>()
            .To<AddingCoinProgressGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<LevelCompletedProgressGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<SavesTrainingGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<BackgroundMusicGameEnded>()
            .AsCached();
        
        Container
            .Bind<ISubscriber>()
            .To<ProgressDistanceMapGameEnded>()
            .AsSingle();
    }
}