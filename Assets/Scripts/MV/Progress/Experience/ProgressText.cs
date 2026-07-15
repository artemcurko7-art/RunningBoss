using UnityEngine;
using TMPro;

public class ProgressText : ProgressExperienceView
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private TMP_Text _maxValueText;
    
    protected override void OnValueChanged(int value)
    {
        _valueText.text = value.ToString();
        _maxValueText.text = Experience.MaxValue.ToString();
    }
}