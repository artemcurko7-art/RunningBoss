using Game.Scripts.Menu.Game.Ended.Subscriber;
using Game.Scripts.MV.Wallet;
using Game.Scripts.Player.Coin;

namespace Game.Scripts.Menu.Game.Ended
{
    public class AddingCoinInWalletGameEnded : GameEndedSubscriber
    {
        private readonly Wallet _wallet;
        private readonly ICoinData[] _coinDates;

        public AddingCoinInWalletGameEnded(IGame game, Wallet wallet, ICoinData[] coinDates)
            : base(game)
        {
            _wallet = wallet;
            _coinDates = coinDates;
        }

        protected override void OnGameEnded()
        {
            foreach (var data in _coinDates)
            foreach (var coin in data.Coins.Values)
                _wallet.AddCoin(coin.Value);
        }
    }
}