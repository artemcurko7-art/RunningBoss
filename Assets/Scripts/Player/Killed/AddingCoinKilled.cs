public class AddingCoinKilled : KilledSubscriber
{
    private readonly CoinData _data;
    private readonly GamePoint _gamePoint;
    private readonly CoinStats _stats;
    
    public AddingCoinKilled(IKilled killed, CoinData data, GamePoint gamePoint, CoinStats stats)
        : base(killed)
    {
        _data = data;
        _gamePoint = gamePoint;
        _stats = stats;
    }

    protected override void OnKilled()
    {
        _data.Coins[CoinType.Killed].Add(_stats.Killed);
        _gamePoint.Add(_stats.Killed);
    }
}