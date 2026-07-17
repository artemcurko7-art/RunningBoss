using Game.Scripts.Animal;
using Game.Scripts.Effector;
using Game.Scripts.Effector.Type;
using Game.Scripts.Player.Death.Subscriber;
using Game.Scripts.PoolMono.Pool;

namespace Game.Scripts.Player.Death
{
    public class EffectorDeath : DeathSubscriber
    {
        private readonly EffectorData _data;
        private readonly EffectorPool _pool;
        private readonly AnimalView _animalView;

        public EffectorDeath(IDeath death, EffectorData data, EffectorPool pool, AnimalView animalView)
            : base(death)
        {
            _data = data;
            _pool = pool;
            _animalView = animalView;
        }

        protected override void OnDied()
        {
            _pool.Spawn(_data.Effectors[EffectorType.Death], _animalView.transform);
        }
    }
}