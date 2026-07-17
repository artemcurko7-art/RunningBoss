using Game.Scripts.Animal.Type;
using Game.Scripts.Inventory.Type;
using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG 
    {
        public List<AnimalType> TotalAmountAnimals = new ();
        public Dictionary<AnimalType, ItemType> OwnedByItems = new ();
        public ItemType SelectedItemType;
        public int SelectorItemViewIndex;
    }
}