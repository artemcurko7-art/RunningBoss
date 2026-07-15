using System;
using System.Collections;
using UnityEngine;

public abstract class PhysicalBody<T>: MonoBehaviour where T : PhysicalBody<T>
{
    private const int TimeLife = 10;
    public event Action<T> Disabled;
    
    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public virtual void ResetSettings()
    {
        transform.position = Vector3.zero;
    }
    
    public void OnDisabled()
    {
        Disabled?.Invoke(this as T);
    }
    
    protected IEnumerator StartTimeLife()
    {
        float elapsedTime = 0;

        while (elapsedTime <= TimeLife)
        {
            yield return null;
            
            if (GamePaused.Type == GamePausedType.Pause)
                continue;

            elapsedTime += Time.deltaTime;
        }

        OnDisabled();
    }
}