using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class AnimalViewShop : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private PrefabLocalization _nameLocalization;
    [SerializeField] private TMP_Text _priceText;
    
    private AnimalService _animalService;
    
    [field: SerializeField] public GameObject Purchased { get; private set; }
    
    public AnimalType Type { get; private set; }
    public int Price { get; private set; }
    
    [Inject]
    public void Construct(AnimalService animalService)
    {
        _animalService = animalService;
    }

    public void Initialize(AnimalType type, Sprite icon, string nameRussian, string nameEnglish, string nameTurkish, int price)
    {
        Type = type;
        _icon.sprite = icon;
        _nameLocalization.Initialize(YG2.envir.language, nameRussian, nameEnglish, nameTurkish);
        Price = price;
        _priceText.text = price.ToString();
        transform.localScale = Vector3.one;
    }
}