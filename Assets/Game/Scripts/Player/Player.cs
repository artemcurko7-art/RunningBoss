using Game.Scripts.Animal;
using Game.Scripts.Menu.Game.Paused;
using Game.Scripts.Menu.Game.Paused.Type;
using Game.Scripts.MV.Speed;
using Game.Scripts.MV.Stat.Health;
using Game.Scripts.MVC.Stat.Type;
using Game.Scripts.Player.Movement;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour, IDamagable.IDamagable
    {
        private const float Percent = 100;
        private MoverForward _moverForward;
        private Health _health;
        private AnimalView _animalView;
        private ISpeed _speed;
        private Rigidbody _rigidbody;

        private void Update()
        {
            if (GamePaused.Type == GamePausedType.Pause)
                return;

            _moverForward.Move(_rigidbody, Vector3.forward, _speed.Value);
        }

        [Inject]
        public void Construct(MoverForward moverForward, Health health, AnimalView animalView, ISpeed speed)
        {
            _moverForward = moverForward;
            _health = health;
            _animalView = animalView;
            _speed = speed;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void TakeDamage(int damage)
        {
            float calculationPercent = (float)damage / Percent;
            float calculationTakeover = _animalView.Animal.Stats[StatType.Armor].Value * calculationPercent;
            float calculationDamage = damage - calculationTakeover;

            _health.TakeDamage((int)calculationDamage);
        }
    }
}