using UnityEngine;
using YG;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private ItemCell _itemCell;
    [SerializeField] private RectTransform _mobileContainer;
    [SerializeField] private RectTransform _desktopContainer;
    
    private RectTransform _currentContainer;
    
    public override void InstallBindings()
    {
        _currentContainer = YG2.envir.isMobile ? _mobileContainer : _desktopContainer;
        
        Container.
            BindInterfacesAndSelfTo<InventoryService>().
            AsSingle().
            WithArguments(_currentContainer);
        
        Container.
            Bind<ItemCellFactory>().
            AsSingle().
            WithArguments(_itemCell);
    }
}