public class SelectorItemUpdater 
{
    private readonly SelectorStorageData _storageData;
    
    public SelectorItemUpdater(SelectorStorageData storageData)
    {
        _storageData = storageData;
    }
    
    public void Update(ItemType type, IAnimalData animalData, AnimalView animalView, InventoryService inventoryService, int oldIndex, out int index)
    {
        index = oldIndex;
        
        for (int i = 0; i < animalView.ItemContainer.transform.childCount; i++)
            animalView.ItemContainer.transform.GetChild(i).gameObject.SetActive(false);
        
        foreach (var view in inventoryService.FilledItemViews)
        {
            if (type == view.Type)
            {
                animalData.Views[animalView.Animal.Type].Animal.SetItem(view);
                animalView.ItemContainer.transform.GetChild(index).gameObject.SetActive(true);
                
                _storageData.Save(animalView, type);
            }
            
            index++;
        } 

        index = 0;
    }
}
