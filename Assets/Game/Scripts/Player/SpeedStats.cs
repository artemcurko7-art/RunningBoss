using UnityEngine;

namespace Game.Scripts.Player
{
    public class SpeedStats : MonoBehaviour
    {
        [field: SerializeField] public float DefaultValue;
        [field: SerializeField] public float RaiseValue;
        [field: SerializeField] public float Delay;
    }
}