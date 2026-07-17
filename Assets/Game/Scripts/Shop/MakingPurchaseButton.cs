using Game.Scripts.Service;
using Game.Scripts.Service.Selector.Animal;
using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Type;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

namespace Game.Scripts.Shop
{
    public class MakingPurchaseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private AnimalViewShop _view;

        private MakingPurchasedService _service;
        private AnimalService _animalService;
        private IAnimalSelectedButton _selected;
        private SoundService _soundService;

        [Inject]
        public void Construct(MakingPurchasedService service, AnimalService animalService,
            IAnimalSelectedButton selected, SoundService soundService)
        {
            _service = service;
            _animalService = animalService;
            _selected = selected;
            _soundService = soundService;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (_service.CanPay(_view.Price))
            {
                _animalService.Set(_view.Type);
                YG2.saves.PurchasedAnimalTypes.Add(_view.Type);
                _view.Purchased.SetActive(true);
                _selected.Update();
                _soundService.Sounds[SoundType.StatLevelUp].Play();
            }
        }
    }
}