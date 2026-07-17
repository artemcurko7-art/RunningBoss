using UnityEngine;

namespace Game.Scripts.Player
{
    public class CoinStats : MonoBehaviour
    {
        [field: SerializeField] public int Killed { get; private set; }
        [field: SerializeField] public int Finished { get; private set; }
        [field: SerializeField] public int LevelUpped { get; private set; }
    }
}