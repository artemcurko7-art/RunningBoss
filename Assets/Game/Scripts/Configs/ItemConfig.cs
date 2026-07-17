using Game.Scripts.Inventory.ItemContext;
using Game.Scripts.Inventory.Type;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Source/Config/Item", fileName = "ItemConfig", order = 6)]

    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemType Type { get; private set; }
        [field: SerializeField] public ItemView View { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string NameRussian { get; private set; }
        [field: SerializeField] public string NameEnglish { get; private set; }
        [field: SerializeField] public string NameTurkish { get; private set; }
    }
}