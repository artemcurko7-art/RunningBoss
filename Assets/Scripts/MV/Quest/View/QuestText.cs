using System;
using TMPro;
using UnityEngine;

public class QuestText : QuestExperienceView
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private TMP_Text _maxValueText;
    
    protected override void OnValueChanged(int value)
    {
        _valueText.text = value.ToString();
        _maxValueText.text = Quest.MaxValue.ToString();
    }
}