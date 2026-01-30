using System;
using UnityEngine;

public interface IProcessingDetection
{
    event Action<Transform> Detected;
}