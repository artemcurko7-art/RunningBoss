using YG;

public class AddingValueKilledLeaderboard : ISubscriber
{
    private const string Name = "Kill";
    private readonly IGame _game;
    private readonly IKilled _killed;
    private int _amount;
    
    public AddingValueKilledLeaderboard(IGame game, IKilled killed)
    {
        _game = game;
        _killed = killed;
    }
    
    public void Subscribe()
    {
        _game.Ended += OnGameEnded;
        _killed.Killed += OnKilled;
    }

    public void Unsubscribe()
    {
        _game.Ended -= OnGameEnded;
        _killed.Killed -= OnKilled;
    }

    private void OnGameEnded()
    {
        int score = (int)YG2.saves.Leaderboards[Name]++;
        YG2.SetLeaderboard(Name, score);
        YG2.GetLeaderboard(Name);
    }

    private void OnKilled()
    {
        _amount++;
    }
}