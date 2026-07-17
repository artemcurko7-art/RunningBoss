using Game.Scripts.Inventory.Type;
using UnityEngine;

namespace Game.Scripts.Inventory.ItemContext
{
    public class ItemView : MonoBehaviour
    {
        public ItemType Type { get; private set; }
        public Item Item { get; private set; }

        public void Initialize(ItemType type, Item item)
        {
            Type = type;
            Item = item;
        }
    }
}