using UnityEngine;

namespace Game.Scripts.Player
{
    public class ExperienceStats : MonoBehaviour
    {
        [field: SerializeField] public int MultiplierMaxValue { get; private set; }
        [field: SerializeField] public int Killed { get; private set; }
        [field: SerializeField] public int Finished { get; private set; }
    }
}