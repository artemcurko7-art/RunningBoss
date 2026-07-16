using DG.Tweening;
using TMPro;
using UnityEngine;

public class HealthText : HealthView
{
    [SerializeField] private TMP_Text _text;
    
    private int _oldValue;

    protected override void OnValueChanged(int value)
    {
        DOTween.To(
            () => _oldValue, 
            x => 
        {
            _oldValue = x;
            _text.text = _oldValue.ToString();
        }, 
            value, 
            0.3f);
    }
}