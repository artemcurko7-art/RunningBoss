using YG;

public class QuestKilled : KilledSubscriber
{
    private readonly QuestData[] _dates;
    
    public QuestKilled(IKilled killed, QuestData[] dates) 
        : base(killed)
    {
        _dates = dates;
    }

    protected override void OnKilled()
    {
        QuestType type = QuestType.Killed;
        
        foreach (var data in _dates)
        {
            if (data.Quests.ContainsKey(type))
            {
                data.Quests[type].Add(1);
                YG2.saves.QuestStorage(data.Quests[type]);
            }
        }
    }
}