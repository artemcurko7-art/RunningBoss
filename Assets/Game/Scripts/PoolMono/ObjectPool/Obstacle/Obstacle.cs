using UnityEngine;

namespace Game.Scripts.PoolMono.ObjectPool.Obstacle
{
    public class Obstacle : PhysicalBody<Obstacle>
    {
        [SerializeField] private Vector3 _rotation;
        [SerializeField] private int _damage;

        private Coroutine _startTimeLife;

        private void OnEnable()
        {
            _startTimeLife = StartCoroutine(StartTimeLife());
        }

        private void OnDisable()
        {
            if (_startTimeLife != null)
                StopCoroutine(_startTimeLife);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out IDamagable.IDamagable damagable))
            {
                damagable.TakeDamage(_damage);
                OnDisabled();
            }
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
            transform.rotation = Quaternion.Euler(_rotation);
        }
    }
}