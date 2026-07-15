using UnityEngine;
using YG;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Vector3 _mobileScale;
    [SerializeField] private Vector3 _desktopScale;
    
    public ItemType Type { get; private set; }
    public Item Item { get; private set; }

    public void Initialize(ItemType type, Item item)
    {
        Type = type;
        Item = item;
        
        transform.localScale = YG2.envir.isMobile ? _mobileScale : _desktopScale;
    }
}