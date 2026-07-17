using Game.Scripts.Factories;
using Game.Scripts.Inventory.ItemContext;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalFactoryInstaller : MonoInstaller
    {
        [SerializeField] private ItemCell _itemCell;

        public override void InstallBindings()
        {
            Container
                .Bind<AnimalViewFactory>()
                .AsSingle();

            Container
                .Bind<AnimalFactory>()
                .AsSingle();

            Container
                .Bind<ItemViewFactory>()
                .AsSingle();

            Container
                .Bind<ItemCellFactory>()
                .AsSingle()
                .WithArguments(_itemCell);

            Container
                .Bind<ProgressFactory>()
                .AsSingle();
        }
    }
}