public class AddingCoinDistanceMapGameEnded : GameEndedSubscriber
{
    private readonly IDistanceMap _distanceMap;
    private readonly CoinData _data;
    
    public AddingCoinDistanceMapGameEnded(IGame game, IDistanceMap distanceMap, CoinData data) : base(game)
    {
        _distanceMap = distanceMap;
        _data = data;
    }
    
    protected override void OnGameEnded()
    {
        float calculation = _distanceMap.CompletedValue * 0.2f;
        
        _data.Coins[CoinType.Distance].Add((int)calculation);
    }
}