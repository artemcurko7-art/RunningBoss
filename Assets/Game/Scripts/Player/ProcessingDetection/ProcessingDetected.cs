using System;
using Game.Scripts.Player.Killed;
using Game.Scripts.PoolMono.ObjectPool.Unit;
using UnityEngine;

namespace Game.Scripts.Player.ProcessingDetection
{
    public class ProcessingDetected : MonoBehaviour, IProcessingDetected, IKilled
    {
        public event Action<Unit> Detected;
        public event Action Killed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Unit unit))
            {
                if (this == null || unit.Death == null)
                    return;

                Detected?.Invoke(unit);
                Killed?.Invoke();
            }
        }
    }
}