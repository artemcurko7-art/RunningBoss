using Game.Scripts.Sound.Type;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Source/Config/BackgroundMusic", fileName = "BackgroundMusic", order = 9)]

    public class BackgroundMusicConfig : ScriptableObject
    {
        [field: SerializeField] public BackgroundMusicType Type { get; private set; }
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
    }
}