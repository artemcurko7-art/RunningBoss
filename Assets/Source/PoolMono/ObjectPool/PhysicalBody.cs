using System.Collections;
using UnityEngine;

public abstract class PhysicalBody : MonoBehaviour
{
    [field: SerializeField] protected float StartWait { get; private set; }
    
    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
        StartCoroutine(StartWaitAddingToPool());
    }

    public virtual void ResetSettings()
    {
        transform.position = Vector3.zero;
    }

    protected abstract IEnumerator StartWaitAddingToPool();
}
