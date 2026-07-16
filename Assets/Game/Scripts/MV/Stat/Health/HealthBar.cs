using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthView
{
    [SerializeField] private Image _filling;

    protected override void OnValueChanged(int value)
    {
        _filling.DOFillAmount((float)value / Model.MaxValue, 0.3f);
    }
}