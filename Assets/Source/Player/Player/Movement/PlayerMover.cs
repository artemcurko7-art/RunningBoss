using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMover : Mover
{
    public PlayerMover(Transform transform, float speed) : base(transform, speed) { }

    public override void Move(Vector3 direction)
    {
        Transform.Translate(direction * Speed * Time.deltaTime);
    }
}
