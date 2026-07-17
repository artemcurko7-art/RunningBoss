using Game.Scripts.Player.Coin;
using Game.Scripts.Player.Coin.Type;
using Game.Scripts.Player.Finished.Subscriber;

namespace Game.Scripts.Player.Finished
{
    public class AddingCoinFinished : FinishedSubscriber
    {
        private readonly CoinStats _stats;
        private readonly CoinData _data;

        public AddingCoinFinished(IFinished finished, CoinData data, CoinStats stats)
            : base(finished)
        {
            _stats = stats;
            _data = data;
        }

        protected override void OnFinished()
        {
            _data.Coins[CoinType.Finished].Add(_stats.Finished);
        }
    }
}