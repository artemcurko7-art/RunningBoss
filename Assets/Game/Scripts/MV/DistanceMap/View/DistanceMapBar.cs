using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.MV.DistanceMap.View
{
    public class DistanceMapBar : DistanceMapView
    {
        [SerializeField] private Slider _slider;

        protected override void OnValueChanged(float value)
        {
            float currentValue = Model.MaxValue - value;
            _slider.value = currentValue / Model.MaxValue;
        }
    }
}