using System.Collections.Generic;

public interface IInventoryService 
{
    IReadOnlyList<ItemView> FilledItemViews { get; }
}
