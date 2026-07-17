using Game.Scripts.MV.Quest.QuestData;
using Game.Scripts.MV.Quest.Type;
using Game.Scripts.Player.Death;
using Game.Scripts.Player.Finished;
using Game.Scripts.Service;
using YG;

namespace Game.Scripts.Menu.Game.Ended
{
    public class QuestCompletedLevelNotDeathGameEnded : ISubscriber
    {
        private const QuestType _type = QuestType.LevelNotDeath;
        private readonly IFinished _finished;
        private readonly IDeath _death;
        private readonly QuestData[] _dates;

        public QuestCompletedLevelNotDeathGameEnded(IFinished finished, IDeath death, QuestData[] dates)
        {
            _finished = finished;
            _death = death;
            _dates = dates;
        }

        public void Subscribe()
        {
            _finished.Finished += OnFinished;
            _death.Died += OnDeath;
        }

        public void Unsubscribe()
        {
            _finished.Finished -= OnFinished;
            _death.Died -= OnDeath;
        }

        private void OnDeath()
        {
            foreach (var data in _dates)
            {
                if (data.Quests.ContainsKey(_type) && data.Quests[_type].IsCompleted == false)
                {
                    data.Quests[_type].Add(-int.MaxValue);
                    YG2.saves.QuestStorage(data.Quests[_type]);
                }
            }
        }

        private void OnFinished()
        {
            foreach (var data in _dates)
            {
                if (data.Quests.ContainsKey(_type))
                {
                    data.Quests[_type].Add(1);
                    YG2.saves.QuestStorage(data.Quests[_type]);
                }
            }
        }
    }
}