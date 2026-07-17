using Game.Scripts.Menu.Game.Ended.Subscriber;
using Game.Scripts.MV.DistanceMap.Model;
using Game.Scripts.Player.Coin;
using Game.Scripts.Player.Coin.Type;

namespace Game.Scripts.Menu.Game.Ended
{
    public class AddingCoinDistanceMapGameEnded : GameEndedSubscriber
    {
        private readonly IDistanceMap _distanceMap;
        private readonly CoinData _data;

        public AddingCoinDistanceMapGameEnded(IGame game, IDistanceMap distanceMap, CoinData data)
            : base(game)
        {
            _distanceMap = distanceMap;
            _data = data;
        }

        protected override void OnGameEnded()
        {
            float calculation = _distanceMap.CompletedValue * 0.2f;

            _data.Coins[CoinType.Distance].Add((int)calculation);
        }
    }
}