using System.Collections.Generic;
using Game.Scripts.Inventory.ItemContext;

namespace Game.Scripts.Service.Inventory
{
    public interface IInventoryService
    {
        IReadOnlyList<ItemView> FilledItemViews { get; }
    }
}