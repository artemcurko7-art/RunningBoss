using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

public abstract class QuestData
{
    private const string Format = "yyyy-MM-dd";
    private readonly Dictionary<QuestType, Quest> _quests = new ();
    
    public IReadOnlyDictionary<QuestType, Quest> Quests => _quests;
    public QuestConfig[] Configs { get; private set; }

    public void Reset()
    {
        foreach (var quest in Quests.Values)
        {
            quest.SetValue(0);

            foreach (var config in Configs)
                if (config.Type == quest.Config.Type)
                    quest.SetReward(config.Reward);
        }
            
        YG2.saves.Quests.Clear();
    }
    
    protected void LoadConfigs(string path)
    {
        Configs = Resources.LoadAll<QuestConfig>(path);
        
        foreach (var type in Enum.GetValues(typeof(QuestType)))
        {
            foreach (var config in Configs)
            {
                if (config.Type == (QuestType)type)
                {
                    if (config.Type == QuestType.None)
                        throw new InvalidCastException($"Not key: {config.Type}");
                
                    if (_quests.ContainsKey(config.Type))
                        throw new InvalidCastException($"There is already such a key: {config.Type}");
                    
                    var quest = new Quest(config);
                    YG2.saves.AddQuest(quest);
                    
                    foreach (var questData in YG2.saves.Quests)
                    {
                        if (questData.Key == quest.Config.KeySave)
                        {
                            quest.SetValue(questData.Value.Value);
                            quest.SetReward(questData.Value.Reward);
                        }
                    }
                    
                    _quests.Add(config.Type, quest);
                }
            }
        }
    }
}