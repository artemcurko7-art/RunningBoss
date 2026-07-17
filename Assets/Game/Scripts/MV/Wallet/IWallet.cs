using System;

namespace Game.Scripts.MV.Wallet
{
    public interface IWallet
    {
        event Action<int> CoinsChanged;
        void Update();
    }
}