using UnityEngine;
using Zenject;

public class GlobalFactoryInstaller : MonoInstaller
{
    [SerializeField] private ItemCell _itemCell;
    
    public override void InstallBindings()
    {
        Container.
            Bind<AnimalViewFactory>().
            AsSingle();
        
        Container.
            Bind<AnimalFactory>().
            AsSingle();
        
        Container.
            Bind<ItemViewFactory>().
            AsSingle();
        
        Container.
            Bind<ItemCellFactory>().
            AsSingle().
            WithArguments(_itemCell);
        
        Container.
            Bind<ProgressFactory>().
            AsSingle();
    }
}