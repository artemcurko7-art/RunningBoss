using Game.Scripts.Inventory.ItemContext;

namespace Game.Scripts.Provider
{
    public class ItemViewProvider : IItemViewProvider
    {
        public ItemView View { get; private set; }

        public void Set(ItemView view)
        {
            View = view;
        }
    }
}