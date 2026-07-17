using Game.Scripts.Menu.Game.Ended.Subscriber;
using Game.Scripts.MV.Progress.Data;
using Game.Scripts.MV.Progress.Type;
using Game.Scripts.Player.Coin;
using YG;

namespace Game.Scripts.Menu.Game.Ended
{
    public class AddingCoinProgressGameEnded : GameEndedSubscriber
    {
        private readonly IProgressData _data;
        private readonly CoinData _coinData;

        public AddingCoinProgressGameEnded(IGame game, IProgressData data, CoinData coinData)
            : base(game)
        {
            _data = data;
            _coinData = coinData;
        }

        protected override void OnGameEnded()
        {
            ProgressType type = ProgressType.Money;

            foreach (var coin in _coinData.Coins.Values)
            {
                _data.Progresses[type].SetValue(coin.Value);
                YG2.saves.ProgressStorage(_data.Progresses[type]);
            }
        }
    }
}