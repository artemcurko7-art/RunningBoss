using YG;

public class AddingCoinProgressGameEnded : GameEndedSubscriber
{
    private readonly IProgressData _data;
    private readonly CoinData _coinData;
    
    public AddingCoinProgressGameEnded(IGame game, IProgressData data, CoinData coinData) : base(game)
    {
        _data = data;
        _coinData = coinData;
    }
    
    protected override void OnGameEnded()
    {
        ProgressType type = ProgressType.Money;

        foreach (var coin in _coinData.Coins.Values)
        {
            _data.Progresses[type].SetValue(coin.Value);
            YG2.saves.ProgressStorage(_data.Progresses[type]);
        }
    }
}