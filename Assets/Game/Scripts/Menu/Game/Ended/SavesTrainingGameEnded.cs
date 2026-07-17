using Game.Scripts.Menu.Game.Ended.Subscriber;
using YG;

namespace Game.Scripts.Menu.Game.Ended
{
    public class SavesTrainingGameEnded : GameEndedSubscriber
    {
        private readonly IGame _game;

        public SavesTrainingGameEnded(IGame game)
            : base(game)
        {
        }

        protected override void OnGameEnded()
        {
            YG2.saves.IsSavesTraining = true;
        }
    }
}