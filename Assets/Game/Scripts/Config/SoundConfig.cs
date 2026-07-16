using UnityEngine;

[CreateAssetMenu(menuName = "Source/Config/Sound", fileName = "Sound", order = 8)]
public class SoundConfig : ScriptableObject
{
    [field: SerializeField] public SoundType Type { get; private set; }
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
}