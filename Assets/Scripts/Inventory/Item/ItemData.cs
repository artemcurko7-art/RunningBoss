using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ItemData 
{
    private readonly ItemConfig[] _configs;
    private readonly Dictionary<ItemType, ItemConfig> _itemConfigs = new();
    private readonly Dictionary<ItemType, ItemView> _views = new();
    
    public ItemData()
    {
        _configs = Resources.LoadAll<ItemConfig>("Config/Item");
        
        Fill();
    }
    
    public IReadOnlyDictionary<ItemType, ItemView> Views => _views;
    public IReadOnlyDictionary<ItemType, ItemConfig> Configs => _itemConfigs;

    private void Fill()
    {
        foreach (var type in Enum.GetValues(typeof(ItemType)))
        {
            foreach (var config in _configs)
            {
                if ((ItemType)type == config.Type)
                {
                    if (config.Type == ItemType.None)
                        throw new InvalidOperationException($"Not key: {config.Type}");

                    if (_views.ContainsKey(config.Type))
                        throw new InvalidOperationException($"There is already such a key: {config.Type}");
                    
                    YG2.saves.InventoryItems.TryAdd(config.Type, 0);
                    config.View.Initialize(config.Type, new Item());
                    config.View.Item.AddDegreeOfOccupancy(YG2.saves.InventoryItems[config.Type]);
                    _views.Add(config.Type, config.View);
                    _itemConfigs.Add(config.Type, config);
                }
            }
        }
    }
}