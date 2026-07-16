using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class SpeedText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private ISpeed _model;
    private float _oldValue;
    
    [Inject]
    public void Construct(ISpeed model)
    {
        _model = model;
        
        _model.Changed += OnValueChanged;
        OnValueChanged(_model.Value);
    }

    private void OnDestroy()
    {
        _model.Changed -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        DOTween.To(
            () => _oldValue, 
            x => 
        {
            _oldValue = x;
            _text.text = _oldValue.ToString("0.00");
        }, 
            value, 
            0.3f);
    }
}