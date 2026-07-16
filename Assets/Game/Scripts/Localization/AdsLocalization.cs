using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class AdsLocalization : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private string _titleRussian;
    [SerializeField] private string _titleEnglish;
    [SerializeField] private string _titleTurkish;
    [SerializeField] private string _descriptionRussian;
    [SerializeField] private string _descriptionEnglish;
    [SerializeField] private string _descriptionTurkish;

    [Inject]
    public void Consruct()
    {
        YG2.onSwitchLang += OnSwitchLanguage;
        OnSwitchLanguage(YG2.envir.language != YG2.saves.Language ? YG2.saves.Language : YG2.envir.language);
    }

    private void OnDestroy()
    {
        YG2.onSwitchLang -= OnSwitchLanguage;
    }

    private void OnSwitchLanguage(string language)
    {
        switch (language)
        {
            case "ru":
                _titleText.text = _titleRussian;
                _descriptionText.text = _descriptionRussian;
                break;
            
            case "en":
                _titleText.text = _titleEnglish;
                _descriptionText.text = _descriptionEnglish;
                break;
            
            case "tr":
                _titleText.text = _titleTurkish;
                _descriptionText.text = _descriptionTurkish;
                break;
        }
    }
}