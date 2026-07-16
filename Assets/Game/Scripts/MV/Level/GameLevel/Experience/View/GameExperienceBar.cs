using UnityEngine;
using UnityEngine.UI;

public class GameExperienceBar : GameExperienceView
{
    [SerializeField] private Image _filling;

    protected override void OnValueChanged(int value, int maxValue)
    {
        _filling.fillAmount = (float)value / maxValue;
    }
}