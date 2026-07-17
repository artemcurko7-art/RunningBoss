using Game.Scripts.Animation;
using Game.Scripts.Player.Killed.Subscriber;
using UnityEngine;

namespace Game.Scripts.Player.Killed
{
    public class PlayerAnimationKilled : KilledSubscriber
    {
        private readonly Animator _animator;

        public PlayerAnimationKilled(IKilled killed, Animator animator)
            : base(killed)
        {
            _animator = animator;
        }

        protected override void OnKilled()
        {
            _animator.SetTrigger(PlayerAnimatorData.Params.Attack);
        }
    }
}