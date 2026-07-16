using YG;

public class QuestDistanceMapGameEnded : GameEndedSubscriber
{
    private readonly QuestData[] _dates;
    private readonly IDistanceMap _distanceMap;
    
    public QuestDistanceMapGameEnded(IGame game, QuestData[] dates, IDistanceMap distanceMap) 
        : base(game)
    {
        _dates = dates;
        _distanceMap = distanceMap;
    }
    
    protected override void OnGameEnded()
    {
        QuestType type = QuestType.Distance;
        
        foreach (var data in _dates)
        {
            if (data.Quests.ContainsKey(type))
            {
                data.Quests[type].Add((int)_distanceMap.CompletedValue);
                YG2.saves.QuestStorage(data.Quests[type]);
            }
        }
    }
}