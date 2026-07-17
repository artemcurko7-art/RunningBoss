using TMPro;
using UnityEngine;

namespace Game.Scripts.MV.Level.GameLevel.Experience.View
{
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
}