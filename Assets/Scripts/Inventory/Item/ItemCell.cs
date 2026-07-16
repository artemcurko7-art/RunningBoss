using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private Image _filling;
    [SerializeField] private Image _empty;
    [SerializeField] private PrefabLocalization _nameLocalization;
    [SerializeField] private float _percent;
    [SerializeField] private float _duration;
    
    [field: SerializeField] public SelectorItemButton Selector { get; private set; }
    public ItemType Type { get; private set; }
    public float FillAmount { get; private set; }
    
    public void Initialize(ItemType type, Sprite icon, string nameRussian, string nameEnglish, string nameTurkish, float fillAmount)
    {
        Type = type;
        _filling.sprite = icon;
        _empty.sprite = icon;
        _nameLocalization.Initialize(YG2.envir.language != YG2.saves.Language ? YG2.saves.Language : YG2.envir.language, nameRussian, nameEnglish, nameTurkish);
        
        Selector.Initialize(Type);
        Fill(fillAmount);
        
        transform.localScale = Vector3.one;
    }
    
    private void Fill(float fillAmount)
    {
        _filling.fillAmount = fillAmount;
        FillAmount = _filling.fillAmount * _percent;
        
        _filling.DOFillAmount(FillAmount, _duration).SetEase(Ease.Linear);
        transform.localScale = Vector3.one;
    }
}