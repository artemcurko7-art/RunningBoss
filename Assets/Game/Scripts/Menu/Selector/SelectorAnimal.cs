using Game.Scripts.Service.Selector;
using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Type;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Menu.Selector
{
    public class SelectorAnimal : MonoBehaviour
    {
        [SerializeField] private Button _rightButton;
        [SerializeField] private Button _leftButton;

        private ISelectorService _selector;
        private SoundService _soundService;

        [Inject]
        public void Construct(ISelectorService selector, SoundService soundService)
        {
            _selector = selector;
            _soundService = soundService;
        }

        private void OnEnable()
        {
            _rightButton.onClick.AddListener(OnClickRight);
            _leftButton.onClick.AddListener(OnClickLeft);
        }

        private void OnDisable()
        {
            _rightButton.onClick.RemoveListener(OnClickRight);
            _leftButton.onClick.RemoveListener(OnClickLeft);
        }

        private void OnClickRight()
        {
            if (_selector == null)
                return;

            _selector.OnClickRight();
            _soundService.Sounds[SoundType.Tab].Play();
        }

        private void OnClickLeft()
        {
            if (_selector == null)
                return;

            _selector.OnClickLeft();
            _soundService.Sounds[SoundType.Tab].Play();
        }
    }
}