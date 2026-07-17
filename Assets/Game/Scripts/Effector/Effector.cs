using Game.Scripts.PoolMono.ObjectPool;
using UnityEngine;

namespace Game.Scripts.Effector
{
    [RequireComponent(typeof(ParticleSystem))]
    public class Effector : PhysicalBody<Effector>
    {
        private ParticleSystem _particleSystem;
        private Coroutine _startTimeLife;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void OnEnable()
        {
            _startTimeLife = StartCoroutine(StartTimeLife());
        }

        private void OnDisable()
        {
            if (_startTimeLife != null)
                StopCoroutine(_startTimeLife);
        }
    }
}