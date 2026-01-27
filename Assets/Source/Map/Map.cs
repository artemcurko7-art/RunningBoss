using System;
using UnityEngine;

public class Map : MonoBehaviour
{
    public event Action<Map> Collided;

    public void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public void ResetSettings()
    {
        transform.position = Vector3.zero;
    }
}
