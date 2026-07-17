using Game.Scripts.Inventory.ItemContext;

namespace Game.Scripts.Provider
{
    public interface IItemViewProvider
    {
        public ItemView View { get; }
    }
}