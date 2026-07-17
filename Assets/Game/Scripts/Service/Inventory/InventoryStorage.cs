using Game.Scripts.Inventory.Type;
using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG
    {
        public Dictionary<ItemType, float> InventoryItems = new ();
        public List<ItemType> FilledItemTypes = new ();
    }
}