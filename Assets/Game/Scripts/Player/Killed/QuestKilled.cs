using Game.Scripts.MV.Quest.QuestData;
using Game.Scripts.MV.Quest.Type;
using Game.Scripts.Player.Killed.Subscriber;
using YG;

namespace Game.Scripts.Player.Killed
{
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
}