using Game.Scripts.Animal.Type;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Source/Config/Animal/Shop", fileName = "AnimalShop", order = 2)]
    public class AnimalShopConfig : ScriptableObject
    {
        [field: SerializeField] public AnimalType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string NameRussian { get; private set; }
        [field: SerializeField] public string NameEnglish { get; private set; }
        [field: SerializeField] public string NameTurkish { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
    }
}