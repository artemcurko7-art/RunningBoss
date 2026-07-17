using Game.Scripts.Animation;
using Game.Scripts.Player.Death;
using Game.Scripts.Player.Finished;
using Game.Scripts.Service;
using UnityEngine;

namespace Game.Scripts.Menu.Game.Ended
{
    public class ChangingAnimationAnimalViewGameEnded : ISubscriber
    {
        private readonly IFinished _finished;
        private readonly IDeath _death;
        private readonly Animator _animator;

        public ChangingAnimationAnimalViewGameEnded(IFinished finished, IDeath death, Animator animator)
        {
            _finished = finished;
            _death = death;
            _animator = animator;
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

        private void OnFinished()
        {
            _animator.SetBool(PlayerAnimatorData.Params.IsRun, false);
        }

        private void OnDeath()
        {
            _animator.SetTrigger(PlayerAnimatorData.Params.Death);
        }
    }
}