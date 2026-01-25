using System.Collections.Generic;
using UnityEngine;

public class RandomPosition
{
    public Vector3 Get(Transform parentSpawn)
    {
        int index = Random.Range(0, parentSpawn.childCount);
        Vector3 position = parentSpawn.GetChild(index).position;

        return position;
    }
}
