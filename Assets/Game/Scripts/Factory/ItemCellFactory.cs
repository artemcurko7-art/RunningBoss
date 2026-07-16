using UnityEngine;
using Zenject;

public class ItemCellFactory
{
    private readonly ItemCell _cell;
    private readonly DiContainer _container;
    
    public ItemCellFactory(ItemCell cell, DiContainer container)
    {
        _cell = cell;
        _container = container;
    }

    public ItemCell Create(ItemConfig config, RectTransform container, float degreeOfOccupancy)
    {
        var cell = _container.InstantiatePrefabForComponent<ItemCell>(_cell, container.position, Quaternion.identity, container);
        cell.Initialize(config.Type, config.Icon, config.NameRussian, config.NameEnglish, config.NameTurkish, degreeOfOccupancy);
        
        return cell;
    }
}