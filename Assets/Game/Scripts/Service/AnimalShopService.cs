using System;
using System.Collections.Generic;
using Game.Scripts.Animal.Data;
using Game.Scripts.Animal.Type;
using Game.Scripts.Factories;
using Game.Scripts.Shop;
using UnityEngine;
using YG;

namespace Game.Scripts.Service
{
    public class AnimalShopService
    {
        private readonly AnimalViewShopFactory _factory;
        private readonly IAnimalShopConfigs _configs;
        private readonly Dictionary<AnimalType, AnimalViewShop> _views = new();
        private readonly RectTransform _container;

        public AnimalShopService(AnimalViewShopFactory factory, IAnimalShopConfigs configs, RectTransform container)
        {
            _factory = factory;
            _container = container;
            _configs = configs;

            Fill();
        }

        private void Fill()
        {
            foreach (var config in _configs.ShopConfigs)
            {
                if (config.Key == AnimalType.None)
                    throw new InvalidOperationException($"Not type: {config.Key}");

                if (_views.ContainsKey(config.Key))
                    throw new InvalidOperationException($"There is such a key: {config.Key}");

                var viewTemplate = _factory.Create(_container);
                viewTemplate.Initialize(config.Key, config.Value.Icon, config.Value.NameRussian,
                    config.Value.NameEnglish, config.Value.NameTurkish, config.Value.Price);

                foreach (var type in YG2.saves.PurchasedAnimalTypes)
                    if (viewTemplate.Type == type)
                        viewTemplate.Purchased.gameObject.SetActive(true);

                _views.Add(config.Key, viewTemplate);
            }
        }
    }
}