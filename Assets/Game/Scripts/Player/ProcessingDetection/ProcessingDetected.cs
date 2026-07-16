using System;
using UnityEngine;

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