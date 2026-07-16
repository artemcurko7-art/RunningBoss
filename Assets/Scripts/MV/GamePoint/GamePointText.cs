using TMPro;
using UnityEngine;
using Zenject;

public class GamePointText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private IGamePoint _gamePoint;
    
    [Inject]
    public void Construct(IGamePoint gamePoint)
    {
        _gamePoint = gamePoint;
        
        _gamePoint.Changed += OnValueChanged;
    }

    private void OnDestroy()
    {
        _gamePoint.Changed -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}