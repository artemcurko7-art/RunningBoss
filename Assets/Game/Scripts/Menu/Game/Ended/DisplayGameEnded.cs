using Game.Scripts.Player.Coin;
using Game.Scripts.Player.Coin.Type;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Menu.Game.Ended
{
    public class DisplayGameEnded : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelUpped;
        [SerializeField] private TMP_Text _killedText;
        [SerializeField] private TMP_Text _finishedText;
        [SerializeField] private TMP_Text _distanceText;
        [SerializeField] private TMP_Text _finalValueText;

        private ICoinData _coinData;
        private int _calculationFinalValue;

        [Inject]
        public void Construct(ICoinData coinData)
        {
            _coinData = coinData;
        }

        private void OnEnable()
        {
            _levelUpped.text = $"+{_coinData.Coins[CoinType.LevelUpped].Value}";
            _killedText.text = $"+{_coinData.Coins[CoinType.Killed].Value}";
            _finishedText.text = $"+{_coinData.Coins[CoinType.Finished].Value}";
            _distanceText.text = $"+{_coinData.Coins[CoinType.Distance].Value}";

            foreach (var coin in _coinData.Coins.Values)
                _calculationFinalValue += coin.Value;

            _finalValueText.text = $"{_calculationFinalValue}";
        }
    }
}