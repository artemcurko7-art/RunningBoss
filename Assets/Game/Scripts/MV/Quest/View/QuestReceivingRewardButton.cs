using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Type;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

namespace Game.Scripts.MV.Quest.View
{
    public class QuestReceivingRewardButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _completed;
        [SerializeField] private GameObject _ads;

        private Wallet.Wallet _wallet;
        private Quest _quest;
        private SoundService _soundService;
        private int _reward;

        [Inject]
        public void Construct(Wallet.Wallet wallet, SoundService soundService)
        {
            _wallet = wallet;
            _soundService = soundService;
        }

        public void Initialize(Quest quest)
        {
            _quest = quest;
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
            _wallet.AddCoin(_quest.GetReward());
            gameObject.SetActive(false);
            _completed.SetActive(true);
            _ads.SetActive(false);
            _soundService.Sounds[SoundType.StatLevelUp].Play();

            YG2.saves.QuestStorage(_quest);
        }
    }
}