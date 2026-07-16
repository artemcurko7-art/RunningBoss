using TMPro;
using UnityEngine;

public class GameExperienceText : GameExperienceView
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private TMP_Text _maxValueText;
    
    protected override void OnValueChanged(int value, int maxValue)
    {
        _valueText.text = value.ToString();
        _maxValueText.text = maxValue.ToString();
    }
}