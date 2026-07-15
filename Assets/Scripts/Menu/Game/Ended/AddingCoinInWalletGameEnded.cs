public class AddingCoinInWalletGameEnded : GameEndedSubscriber
{
    private readonly Wallet _wallet;
    private readonly ICoinData[] _coinDates;
    
    public AddingCoinInWalletGameEnded(IGame game, Wallet wallet, ICoinData[] coinDates) : base(game)
    {
        _wallet = wallet;
        _coinDates = coinDates;
    }
    
    protected override void OnGameEnded()
    {
         foreach (var data in _coinDates)
             foreach (var coin in data.Coins.Values)
                 _wallet.AddCoin(coin.Value);
    }
}