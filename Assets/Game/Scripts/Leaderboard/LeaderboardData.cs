using YG;

namespace Game.Scripts.Leaderboard
{
    public class LeaderboardData
    {
        public LeaderboardData()
        {
            YG2.saves.Leaderboards.TryAdd("Level", 0);
            YG2.saves.Leaderboards.TryAdd("Kill", 0);
            YG2.saves.Leaderboards.TryAdd("GameTime", 0);
        }
    }
}