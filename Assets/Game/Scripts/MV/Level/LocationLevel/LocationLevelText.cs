using TMPro;
using UnityEngine;
using Zenject;

public class LocationLevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private ILocationLevel _model;
    
    [Inject]
    public void Construct(ILocationLevel model)
    {
        _model = model;

        _model.Changed += OnValueChanged;
        _model.Update();
    }

    private void OnDestroy()
    {
        _model.Changed -= OnValueChanged;
    }
    
    private void OnValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}