using Game.Scripts.MV.Progress.Data;
using Game.Scripts.MV.Progress.Type;
using Game.Scripts.Player.Killed.Subscriber;
using YG;

namespace Game.Scripts.Player.Killed
{
    public class KilledProgress : KilledSubscriber
    {
        private readonly IProgressData _data;

        public KilledProgress(IKilled killed, IProgressData data)
            : base(killed)
        {
            _data = data;
        }

        protected override void OnKilled()
        {
            ProgressType type = ProgressType.Killed;

            _data.Progresses[type].SetValue(1);
            YG2.saves.ProgressStorage(_data.Progresses[type]);
        }
    }
}