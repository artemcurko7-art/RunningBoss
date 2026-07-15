using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlingText : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private const int Percent = 100;
    
    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
        OnValueChanged(_slider.value);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnValueChanged);
    }
    
    private void OnValueChanged(float value)
    {
        float calculationValue = value / _slider.maxValue;
        float percent = calculationValue * Percent; 
        _text.text = $"{(int)percent}%";
    }
}