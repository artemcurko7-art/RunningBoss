using Game.Scripts.Factories;
using Game.Scripts.Service;
using Game.Scripts.Shop;
using UnityEngine;
using YG;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class ShopInstaller : MonoInstaller
    {
        [SerializeField] private AnimalViewShop animalViewShop;
        [SerializeField] private RectTransform _mobileContainer;
        [SerializeField] private RectTransform _desktopContainer;

        private RectTransform _currentContainer;

        public override void InstallBindings()
        {
            _currentContainer = YG2.envir.isMobile ? _mobileContainer : _desktopContainer;

            Container
                .Bind<AnimalViewShop>()
                .FromInstance(animalViewShop)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<AnimalShopService>()
                .AsSingle()
                .WithArguments(_currentContainer)
                .NonLazy();

            Container
                .Bind<AnimalViewShopFactory>()
                .AsSingle();

            Container
                .Bind<MakingPurchasedService>()
                .AsSingle();
        }
    }
}