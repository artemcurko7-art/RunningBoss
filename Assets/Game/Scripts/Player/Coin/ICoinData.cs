using System.Collections.Generic;

public interface ICoinData 
{
    IReadOnlyDictionary<CoinType, Coin> Coins { get; }
}