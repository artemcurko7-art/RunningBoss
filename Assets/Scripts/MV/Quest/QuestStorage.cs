using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG 
    {
        public Dictionary<string, QuestStorageData> Quests = new();

        public void AddQuest(Quest quest)
        {
            if (Quests.ContainsKey(quest.Config.KeySave))
                return;
            
            Quests.Add(quest.Config.KeySave, Create(quest));
        }
        
        public void QuestStorage(Quest quest)
        {
            Quests[quest.Config.KeySave] = Create(quest);
        }
        
        private QuestStorageData Create(Quest quest)
        {
            QuestStorageData data = new()
            {
                Key = quest.Config.KeySave,
                Value = quest.Value,
                Reward = quest.Reward
            };
        
            return data;
        }
    }
}