using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DistanceMapPercentText : DistanceMapView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private const int Percent = 100;

    protected override void OnValueChanged(float value)
    {
        float currentValue = Model.MaxValue - value;
        float calculationPercent = currentValue / Model.MaxValue * Percent;

        _text.text = $"{(int)calculationPercent}%";
    }
}