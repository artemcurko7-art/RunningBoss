using Game.Scripts.Menu.Game.Ended.Subscriber;
using Game.Scripts.MV.Quest.QuestData;
using Game.Scripts.MV.Quest.Type;
using YG;

namespace Game.Scripts.Menu.Game.Ended
{
    public class QuestLevelCompletedGameEnded : GameEndedSubscriber
    {
        private readonly QuestData[] _dates;

        public QuestLevelCompletedGameEnded(IGame game, QuestData[] dates)
            : base(game)
        {
            _dates = dates;
        }

        protected override void OnGameEnded()
        {
            const QuestType type = QuestType.CompletedLevel;

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