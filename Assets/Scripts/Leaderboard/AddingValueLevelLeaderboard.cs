using UnityEngine;
using YG;
using Zenject;

public class AddingValueLevelLeaderboard : ISubscriber
{
    private const string Name = "Level";
    [InjectOptional] private readonly IFinished _finished;
    private readonly LeaderboardData _data;
    
    public AddingValueLevelLeaderboard(IFinished finished, LeaderboardData data)
    {
        _finished = finished;
        _data = data;
    }
    
    public void Subscribe()
    {
        _finished.Finished += OnFinished;
    }

    public void Unsubscribe()
    {
        _finished.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        int score = (int)YG2.saves.Leaderboards[Name]++;
        YG2.SetLeaderboard(Name, score);
        YG2.GetLeaderboard(Name);
    }
}