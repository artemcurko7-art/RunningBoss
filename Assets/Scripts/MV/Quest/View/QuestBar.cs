using UnityEngine;
using UnityEngine.UI;

public class QuestBar : QuestExperienceView
{
    [SerializeField] private Image _filling;
    
    protected override void OnValueChanged(int value)
    {
        if (_filling == null)
            return;

        _filling.fillAmount = (float)value / Quest.MaxValue;
    }
}