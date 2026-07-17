using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.MV.DistanceMap.View
{
    public class DistanceMapPercentText : DistanceMapView
    {
        private const int Percent = 100;

        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _text;

        protected override void OnValueChanged(float value)
        {
            float currentValue = Model.MaxValue - value;
            float calculationPercent = currentValue / Model.MaxValue * Percent;

            _text.text = $"{(int)calculationPercent}%";
        }
    }
}