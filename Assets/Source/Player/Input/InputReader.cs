using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Mouse = KeyCode.Mouse0;

    public event Action MousePressed;

    private void Update()
    {
        if (Input.GetKey(Mouse))
            MousePressed?.Invoke();
    }
}
