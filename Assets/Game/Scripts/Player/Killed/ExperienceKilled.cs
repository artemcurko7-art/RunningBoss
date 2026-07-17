using Game.Scripts.MV.Level.GameLevel.Experience.Model;
using Game.Scripts.Player.Killed.Subscriber;

namespace Game.Scripts.Player.Killed
{
    public class ExperienceKilled : KilledSubscriber
    {
        private readonly IGameExperience _experience;
        private readonly ExperienceStats _stats;

        public ExperienceKilled(IKilled killed, IGameExperience experience, ExperienceStats stats)
            : base(killed)
        {
            _experience = experience;
            _stats = stats;
        }

        protected override void OnKilled()
        {
            _experience.Add(_stats.Killed);
        }
    }
}