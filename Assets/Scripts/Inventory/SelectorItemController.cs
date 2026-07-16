using UnityEngine.UI;
using YG;

public class SelectorItemController : ISubscriber
{
    private readonly IAnimalData _animalData;
    private readonly IAnimalSelected _animalSelected;
    private readonly InventoryService _inventoryService;
    private readonly SelectorAnimalViewService _selectorAnimal;
    private readonly SelectorUIUpdater _uiUpdater;
    private readonly SelectorItemUpdater _itemUpdater;
    private readonly SelectorStorageData _storageData;
    private ItemType _type;
    private AnimalView _animalView;
    private int _index;
    private int _defaultIndex;
    private bool _isFirst;
    
    public SelectorItemController(
        IAnimalData animalData, 
        IAnimalSelected animalSelected, 
        InventoryService inventoryService, 
        SelectorAnimalViewService selectorAnimal, 
        SelectorUIUpdater uiUpdater,
        SelectorItemUpdater itemUpdater,
        SelectorStorageData storageData)
    {
        _animalData = animalData;
        _animalSelected = animalSelected;
        _inventoryService = inventoryService;
        _selectorAnimal = selectorAnimal;
        _uiUpdater = uiUpdater;
        _itemUpdater = itemUpdater;
        _storageData = storageData;
    }

    public void Subscribe()
    {
        foreach (var cell in _inventoryService.Cells)
            cell.Selector.Clicked += OnClicked; 
        
        _animalSelected.Selected += OnSelectedAnimalView;
        _animalSelected.Update();
        
        _index = YG2.saves.SelectorItemViewIndex;
        _type = YG2.saves.SelectedItemType;
    }

    public void Unsubscribe()
    {
        foreach (var cell in _inventoryService.Cells)
            cell.Selector.Clicked -= OnClicked;
        
        _animalSelected.Selected -= OnSelectedAnimalView;
    }

    private void OnClicked(ItemType type, Button button, Image selected)
    {
        _uiUpdater.Update(_inventoryService, button, selected);
        _type = type;
        Select(_type);
    }

    private void Select(ItemType type)
    {
        _itemUpdater.Update(type, _animalData, _animalView, _inventoryService, _index, out int index);
        _index = index;
    }

    private void OnSelectedAnimalView(AnimalView animalView)
    {
        _animalView = animalView;

        foreach (var type in YG2.saves.TotalAmountAnimals)
            if (animalView.Animal.Type == type)
                 Select(YG2.saves.OwnedByItems[animalView.Animal.Type]);
        
        _uiUpdater.Update(_animalView, _inventoryService);
    }
}