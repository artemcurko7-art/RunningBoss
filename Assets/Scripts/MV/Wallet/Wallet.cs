using System;
using YG;

public class Wallet : IWallet
{
    private int _coin;
    
    public event Action<int> CoinsChanged;

    public Wallet()
    {
        _coin = YG2.saves.Coin;
    }
    
    public int Coin
    {
        get => _coin;

        private set
        {
            _coin = Math.Clamp(value, 0, int.MaxValue);
            CoinsChanged?.Invoke(_coin);
            
            YG2.saves.Coin = _coin;
        }
    }

    public void Update()
    {
        CoinsChanged?.Invoke(_coin);
    }

    public void AddCoin(int amount)
    {
        if (amount < 0)
            throw new InvalidOperationException(nameof(amount));

        Coin += amount;
    }

    public void RemoveCoin(int amount)
    {
        if (amount < 0)
            throw new InvalidOperationException(nameof(amount));

        Coin -= amount;
    }
}