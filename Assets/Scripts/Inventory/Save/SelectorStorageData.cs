using YG;

public class SelectorStorageData 
{
    public void Save(ItemType type, int index)
    {
        YG2.saves.SelectedItemType = type;
        YG2.saves.SelectorItemViewIndex = index;
    }

    public void Save(AnimalView animalView, ItemType type)
    {
        if (YG2.saves.OwnedByItems.ContainsKey(animalView.Animal.Type))
            YG2.saves.OwnedByItems[animalView.Animal.Type] = type;
    }
}