using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [field: SerializeField] public float MovementForwardSpeed { get; private set; }
    [field: SerializeField] public float MovementHorizontalSpeed { get; private set; }
    [field: SerializeField] public float ForwardPowerThrow { get; private set; }
    [field: SerializeField] public float UpPowerThrow { get; private set; }
    [field: SerializeField] public float RangePosition { get; private set; }
}