using Game.Scripts.Menu.Game.Ended.Subscriber;
using Game.Scripts.MV.Progress.Data;
using Game.Scripts.MV.Progress.Type;
using YG;

namespace Game.Scripts.Menu.Game.Ended
{
    public class LevelCompletedProgressGameEnded : GameEndedSubscriber
    {
        private readonly IProgressData _data;

        public LevelCompletedProgressGameEnded(IGame game, IProgressData data)
            : base(game)
        {
            _data = data;
        }

        protected override void OnGameEnded()
        {
            ProgressType type = ProgressType.CompletedLevel;

            _data.Progresses[type].SetValue(1);
            YG2.saves.ProgressStorage(_data.Progresses[type]);
        }
    }
}