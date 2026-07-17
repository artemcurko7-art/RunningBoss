using Game.Scripts.MV.Progress.Data;
using Game.Scripts.MV.Progress.Type;
using Game.Scripts.Player.Death.Subscriber;
using YG;

namespace Game.Scripts.Player.Death
{
    public class ProgressDeath : DeathSubscriber
    {
        private readonly IProgressData _data;

        public ProgressDeath(IDeath death, IProgressData data)
            : base(death)
        {
            _data = data;
        }

        protected override void OnDied()
        {
            ProgressType type = ProgressType.Death;

            _data.Progresses[type].SetValue(1);
            YG2.saves.ProgressStorage(_data.Progresses[type]);
        }
    }
}