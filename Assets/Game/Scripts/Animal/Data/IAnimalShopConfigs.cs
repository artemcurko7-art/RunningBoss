using Game.Scripts.Animal.Type;
using Game.Scripts.Configs;
using System.Collections.Generic;

namespace Game.Scripts.Animal.Data
{
    public interface IAnimalShopConfigs
    {
        IReadOnlyDictionary<AnimalType, AnimalShopConfig> ShopConfigs { get; }
    }
}