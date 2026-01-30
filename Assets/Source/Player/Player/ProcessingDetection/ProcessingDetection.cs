using System;
using UnityEngine;

public class ProcessingDetection : MonoBehaviour, IProcessingDetection, IAttacker
{
    public event Action<Transform> Detected;
    public event Action Attacked;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            Detected?.Invoke(interactable.GetTransform());
            Attacked?.Invoke();
        }
    }
}