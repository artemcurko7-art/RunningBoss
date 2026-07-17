using Game.Scripts.MV.Speed;
using Game.Scripts.Player.Damaged.Subscriber;

namespace Game.Scripts.Player.Damaged
{
    public class SlowingSpeedDamaged : DamagedSubscriber
    {
        private readonly Speed _speed;

        public SlowingSpeedDamaged(IDamaged damaged, Speed speed)
            : base(damaged)
        {
            _speed = speed;
        }

        protected override void OnDamaged()
        {
            _speed.Slow();
        }
    }
}