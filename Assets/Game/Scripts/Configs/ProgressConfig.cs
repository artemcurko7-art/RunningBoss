using Game.Scripts.MV.Progress.Type;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Source/Config/Progress", fileName = "ProgressConfig", order = 4)]
    public class ProgressConfig : ScriptableObject
    {
        [field: SerializeField] public ProgressType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string NameRussian { get; private set; }
        [field: SerializeField] public string NameEnglish { get; private set; }
        [field: SerializeField] public string NameTurkish { get; private set; }
        [field: SerializeField] public string DescriptionRussian { get; private set; }
        [field: SerializeField] public string DescriptionEnglish { get; private set; }
        [field: SerializeField] public string DescriptionTurkish { get; private set; }
        [field: SerializeField] public int MaxValue { get; private set; }
        [field: SerializeField] public int Reward { get; private set; }
        [field: SerializeField] public int MultiplierMaxValue { get; private set; }
        [field: SerializeField] public int MultiplierReward { get; private set; }
    }
}