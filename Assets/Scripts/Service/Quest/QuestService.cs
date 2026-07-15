using UnityEngine;

public class QuestService
{
    private readonly QuestData[] _dates;
    private readonly QuestViewFactory _factory;
    private readonly RectTransform[] _containers;
    
    public QuestService(QuestData[] dates, QuestViewFactory factory, RectTransform[] containers)
    {
        _dates = dates;
        _factory = factory;
        _containers = containers;

        Fill();
    }

    private void Fill()
    {
        int index = 0;
        
        foreach (var date in _dates)
        {
            foreach (var quest in date.Quests)
                _factory.Create(quest.Value, _containers[index]); 

            index++;
        }
    }
}