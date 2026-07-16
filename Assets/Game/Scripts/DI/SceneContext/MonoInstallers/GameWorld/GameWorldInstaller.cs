using UnityEngine;
using Zenject;

public class GameWorldInstaller : MonoInstaller
{
    [SerializeField] private ItemCell _cell;
    
    public override void InstallBindings()
    {
        Container
            .Bind<AnimalViewFactory>()
            .AsSingle();
        
        Container
            .Bind<ItemCellFactory>()
            .AsSingle()
            .WithArguments(_cell);
        
        Container
            .Bind<GameWorld>()
            .AsSingle();
    }
}