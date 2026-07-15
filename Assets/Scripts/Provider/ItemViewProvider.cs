public class ItemViewProvider : IItemViewProvider
{
    public ItemView View { get; private set; }
    
    public void Set(ItemView view)
    {
        View = view;
    }
}