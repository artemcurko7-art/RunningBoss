using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AnimalData : IAnimalData, IAnimalShopConfigs
{
    private readonly Dictionary<AnimalType, AnimalView> _views = new();
    private readonly Dictionary<AnimalType, AnimalConfig> _configs = new();
    private readonly Dictionary<AnimalType, AnimalShopConfig> _shopConfigs = new();
    private readonly AnimalFactory _factory;

    private readonly AnimalConfig[] _loadConfigs;
    private readonly AnimalShopConfig[] _loadShopConfigs;
    
    public AnimalData(AnimalFactory factory)
    {
        _factory = factory;
        
        _loadConfigs = Resources.LoadAll<AnimalConfig>("Config/Animal/Animal");
        _loadShopConfigs = Resources.LoadAll<AnimalShopConfig>("Config/Animal/Shop");
        
        Fill();
        FillShopConfigs();
    }

    public IReadOnlyDictionary<AnimalType, AnimalView> Views => _views;
    public IReadOnlyDictionary<AnimalType, AnimalConfig> Configs => _configs;
    public IReadOnlyDictionary<AnimalType, AnimalShopConfig> ShopConfigs => _shopConfigs;
    
    private void Fill()
    {
        foreach (var config in _loadConfigs)
        {
            if (config.Type == AnimalType.None)
                throw new InvalidOperationException($"Not key: {config.Type}");
                
            if (_views.ContainsKey(config.Type))
                throw new InvalidOperationException($"There is already such a key: {config.Type}");
            
            var animal = _factory.Create(config);
            config.View.Initialize(animal);
            _views.Add(config.Type, config.View);
            _configs.Add(config.Type, config);

            if (YG2.saves.TotalAmountAnimals.Contains(config.Type) == false)
                YG2.saves.TotalAmountAnimals.Add(config.Type);
            
            YG2.saves.OwnedByItems.TryAdd(config.Type, ItemType.None);
        }
    }
    
    private void FillShopConfigs()
    {
        foreach (var type in Enum.GetValues(typeof(AnimalType))) 
        {
            foreach (var config in _loadShopConfigs)
            {
                if (config.Type == (AnimalType)type)
                {
                    if ((AnimalType)type == AnimalType.None)
                        throw new InvalidOperationException($"Not key: {type}");
                
                    if (_shopConfigs.ContainsKey(config.Type))
                        throw new InvalidOperationException($"There is already such a key: {config.Type}");

                    _shopConfigs.Add(config.Type, config);
                }
            }
        }
    }
}
