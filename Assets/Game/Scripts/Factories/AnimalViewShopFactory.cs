using Game.Scripts.Shop;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class AnimalViewShopFactory
    {
        private readonly AnimalViewShop _animalViewShop;
        private readonly DiContainer _container;

        public AnimalViewShopFactory(AnimalViewShop animalViewShop, DiContainer container)
        {
            _animalViewShop = animalViewShop;
            _container = container;
        }

        public AnimalViewShop Create(RectTransform container)
        {
            var viewTempate = _container.InstantiatePrefabForComponent<AnimalViewShop>(_animalViewShop,
                container.position, Quaternion.identity, container);

            return viewTempate;
        }
    }
}