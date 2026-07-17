using Game.Scripts.Provider;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

namespace Game.Scripts.Settings.Language
{
    public class SwitchingLanguages : MonoBehaviour
    {
        [SerializeField] private AutoSwitchingLanguage _auto;
        [SerializeField] private Button _button;
        [SerializeField] private Image _selected;
        [SerializeField] private Image[] _allSelecteds;
        [SerializeField] private Button[] _allButtons;
        [SerializeField] private string _language;

        private LanguageProvider _provider;

        [Inject]
        public void Construct(LanguageProvider provider)
        {
            _provider = provider;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);

            if (YG2.saves.Language == _language && _provider.IsAuto == false)
                OnSwitching();

            YG2.onSwitchLang += OnSwitchLanguage;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);

            if (YG2.saves.Language == _language)
                OnSwitching();

            YG2.onSwitchLang -= OnSwitchLanguage;
        }

        private void OnClick()
        {
            _provider.DisableAuto();
            OnSwitching();
            _auto.Switch();
            YG2.SwitchLanguage(YG2.saves.Language);
        }

        private void OnSwitchLanguage(string language)
        {
            if (YG2.saves.Language == _language && _provider.IsAuto == false)
                OnSwitching();
        }

        private void OnSwitching()
        {
            foreach (var selected in _allSelecteds)
                selected.enabled = false;

            foreach (var button in _allButtons)
                button.interactable = true;

            _selected.enabled = true;
            _button.interactable = false;

            YG2.saves.Language = _language;
        }
    }
}