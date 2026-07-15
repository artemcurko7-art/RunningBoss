using TMPro;
using UnityEngine;
using Zenject;

public class GameLevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private IGameLevel _model;
    
    [Inject]
    public void Construct(IGameLevel model)
    {
        _model = model;
    }

    private void OnEnable()
    {
        _model.Upped += OnGameLevelText;
        _model.Update();
    }

    private void OnDisable()
    {
        _model.Upped -= OnGameLevelText;
    }

    private void OnGameLevelText(int value)
    {
        _text.text = value.ToString();
    }
}