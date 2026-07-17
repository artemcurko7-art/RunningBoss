using Game.Scripts.Inventory.Type;
using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Type;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.Inventory
{
    public class SelectorItemButton : MonoBehaviour
    {
        private ItemType _type;
        private SoundService _soundService;

        public event Action<ItemType, Button, Image> Clicked;

        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public Image Selected { get; private set; }

        [Inject]
        public void Construct(SoundService soundService)
        {
            _soundService = soundService;
        }

        public void Initialize(ItemType type)
        {
            _type = type;
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(OnClick);
            Button.onClick.AddListener(OnClickSound);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnClick);
            Button.onClick.RemoveListener(OnClickSound);
        }

        public void OnClick()
        {
            Clicked?.Invoke(_type, Button, Selected);
        }

        public void OnClickSound()
        {
            _soundService.Sounds[SoundType.StatLevelUp].Play();
        }
    }
}