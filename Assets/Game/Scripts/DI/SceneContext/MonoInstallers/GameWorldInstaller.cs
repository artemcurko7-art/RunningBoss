using Game.Scripts.Factories;
using Game.Scripts.GameWorld;
using Game.Scripts.Inventory.ItemContext;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
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
                .Bind<GameWorldProvider>()
                .AsSingle();
        }
    }
}