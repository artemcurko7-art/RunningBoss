using Game.Scripts.MV.Level.LocationLevel;
using Game.Scripts.Player.Finished.Subscriber;

namespace Game.Scripts.Player.Finished
{
    public class RaisingLocationLevelFinished : FinishedSubscriber
    {
        private readonly ILocationLevelUpped _upped;

        public RaisingLocationLevelFinished(IFinished finished, ILocationLevelUpped upped)
            : base(finished)
        {
            _upped = upped;
        }

        protected override void OnFinished()
        {
            _upped.UpLevel();
        }
    }
}