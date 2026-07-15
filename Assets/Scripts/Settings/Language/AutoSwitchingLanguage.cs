using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class AutoSwitchingLanguage : MonoBehaviour
{
    [SerializeField] private ToggleSwitchingLanguage _activateToggle;
    [SerializeField] private ToggleSwitchingLanguage _deactivateToggle;
    [SerializeField] private Image[] _selecteds;
    [SerializeField] private Button[] _buttons;

    LanguageProvider _provider;
    
    [Inject]
    public void Construct(LanguageProvider provider)
    {
        _provider = provider;
    }
    
    public void OnEnable()
    {
        _deactivateToggle.Button.onClick.AddListener(OnClickDeactivated);
        
        if (_provider.IsAuto == false)
            Switch();
    }

    private void OnDisable()
    {
        _deactivateToggle.Button.onClick.RemoveListener(OnClickDeactivated);
    }
    
    public void OnClickDeactivated()
    {
        _activateToggle.gameObject.SetActive(true);
        _deactivateToggle.gameObject.SetActive(false);
        _provider.EnableAuto();
        YG2.SwitchLanguage(YG2.envir.language);

        foreach (var button in _buttons)
            button.interactable = true;
        
        foreach (var selected in _selecteds)
            selected.enabled = false;
    }

    public void Switch()
    {
        _activateToggle.gameObject.SetActive(false);
        _deactivateToggle.gameObject.SetActive(true);
    }
}