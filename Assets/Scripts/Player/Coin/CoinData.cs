using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinData : ICoinData
{
    private readonly Dictionary<CoinType, Coin> _coins = new();
    
    public CoinData()
    {
        foreach (var type in Enum.GetValues(typeof(CoinType)))
            _coins.Add((CoinType)type, new Coin());
    }
    
    public IReadOnlyDictionary<CoinType, Coin> Coins => _coins;
}