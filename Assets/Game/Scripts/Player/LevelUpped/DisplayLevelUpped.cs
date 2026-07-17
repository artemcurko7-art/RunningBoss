using Game.Scripts.Player.Coin;
using Game.Scripts.Player.Coin.Type;
using Game.Scripts.Sound.Effects;
using Game.Scripts.Sound.Type;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.LevelUpped
{
    public class DisplayLevelUpped : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _rewardLevelText;

        private ICoinData _coinData;
        private SoundService _soundService;

        [Inject]
        public void Construct(ICoinData coinData, SoundService soundService)
        {
            _coinData = coinData;
            _soundService = soundService;
        }

        private void OnEnable()
        {
            if (_levelText == null || _rewardLevelText == null)
                return;

            _rewardLevelText.text = _coinData.Coins[CoinType.LevelUpped].Value.ToString();
            _soundService.Sounds[SoundType.GameLevelUp].Play();
        }
    }
}