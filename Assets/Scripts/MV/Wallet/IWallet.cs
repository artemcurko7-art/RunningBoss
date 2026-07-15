using System;

public interface IWallet 
{
    event Action<int> CoinsChanged;
    void Update();
}