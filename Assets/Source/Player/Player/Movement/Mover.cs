using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover 
{
    [SerializeField] protected readonly Transform Transform;
    [SerializeField] protected readonly float Speed;

    public Mover(Transform transform, float speed)
    {
        Transform = transform;
        Speed = speed;
    }

    public abstract void Move(Vector3 direction);
}
