using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : ProgressExperienceView
{
    [SerializeField] private Image _filling;
    
    protected override void OnValueChanged(int value)
    {
         if(_filling == null)
             return;
         
         _filling.fillAmount = (float)value / Experience.MaxValue;
    }
}