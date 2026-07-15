using System.Collections.Generic;

public interface IAnimalShopConfigs 
{
    IReadOnlyDictionary<AnimalType, AnimalShopConfig> ShopConfigs { get; }
}