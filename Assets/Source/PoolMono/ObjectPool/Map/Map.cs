using System;
using System.Collections;
using UnityEngine;

public class Map : PhysicalBody
{
    public event Action<Map> Disabled;

    protected override IEnumerator StartWaitAddingToPool()
    {
        yield return new WaitForSeconds(StartWait);
        
        Disabled?.Invoke(this);
    }
}
