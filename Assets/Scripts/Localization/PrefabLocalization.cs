using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class PrefabLocalization : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    private string _russian;
    private string _english;
    private string _turkish;
    
    [Inject]
    public void Construct()
    {
        YG2.onSwitchLang += OnChangeLanguage;
    }
    
    public void Initialize(string language, string russian, string english, string turkish)
    {
        _russian = russian;
        _english = english;
        _turkish = turkish;
        
        switch (language)
        {
            case "ru":
                _text.text = russian;
                break;
            
            case "en":
                _text.text = english;
                break;
            
            case "tr":
                _text.text = turkish;
                break;
        }
    }

    private void OnDestroy()
    {
        YG2.onSwitchLang -= OnChangeLanguage;
    }
    
    private void OnChangeLanguage(string language)
    {
        Initialize(language, _russian, _english, _turkish);
    }
}