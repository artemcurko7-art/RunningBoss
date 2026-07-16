public class AddingCoinLevelUpped : ISubscriber
{
    private readonly IGameLevelUpped _levelUpped;
    private readonly CoinData _data;
    private readonly IGameLevel _gameLevel;
    private readonly CoinStats _stats;
    
    public AddingCoinLevelUpped(IGameLevelUpped levelUpped, CoinData data, IGameLevel gameLevel, CoinStats stats)
    {
        _levelUpped = levelUpped;
        _data = data;
        _gameLevel = gameLevel;
        _stats = stats;
    }

    public void Subscribe()
    {
        _levelUpped.Upped += OnLevelUpped;
    }

    public void Unsubscribe()
    {
        _levelUpped.Upped -= OnLevelUpped;
    }

    private void OnLevelUpped()
    {
        _data.Coins[CoinType.LevelUpped].Add(_stats.LevelUpped * _gameLevel.Value);
    }
}