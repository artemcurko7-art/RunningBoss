public class MakingPurchasedService
{
    private readonly Wallet _wallet;
    
    public MakingPurchasedService(Wallet wallet)
    {
        _wallet = wallet;
    }

    public bool CanPay(int price)
    {
        if (_wallet.Coin >= price)
        {
            _wallet.RemoveCoin(price);
            return true;
        }
        
        return false;
    }
}