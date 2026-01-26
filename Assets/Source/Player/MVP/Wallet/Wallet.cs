using System;
using UnityEngine;

public class Wallet
{
    public event Action<int> CoinsChanged;

    public int Coin { get; private set; }

    public void AddCoin(int amount)
    {
        if (amount < 0)
            throw new InvalidOperationException(nameof(amount));

        Coin += amount;
        CoinsChanged?.Invoke(Coin);
    }

    public void RemoveCoin(int amount)
    {
        if (amount < 0)
            throw new InvalidOperationException(nameof(amount));

        Coin -= amount;
        CoinsChanged?.Invoke(Coin);
    }
}