using System.Collections.Generic;
using Game.Scripts.Player.Coin.Type;

namespace Game.Scripts.Player.Coin
{
    public interface ICoinData
    {
        IReadOnlyDictionary<CoinType, Coin> Coins { get; }
    }
}