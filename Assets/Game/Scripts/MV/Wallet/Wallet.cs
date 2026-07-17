using System;
using YG;

namespace Game.Scripts.MV.Wallet
{
    public class Wallet : IWallet
    {
        private int _coin;

        public Wallet()
        {
            _coin = YG2.saves.Coin;
        }

        public event Action<int> CoinsChanged;

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
}