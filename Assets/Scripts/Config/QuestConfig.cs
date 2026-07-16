using UnityEngine;

[CreateAssetMenu(menuName = "Source/Config/Quest", fileName = "QuestConfig", order = 5)]
public class QuestConfig : ScriptableObject
{
    [field: SerializeField] public QuestType Type { get; private set; }
    [field: SerializeField] public string KeySave { get; private set; }
    [field: SerializeField] public string NameRussian { get; private set; }
    [field: SerializeField] public string NameEnglish { get; private set; }
    [field: SerializeField] public string NameTurkish { get; private set; }
    [field: SerializeField] public string DescriptionRussian { get; private set; }
    [field: SerializeField] public string DescriptionEnglish { get; private set; }
    [field: SerializeField] public string DescriptionTurkish { get; private set; }
    [field: SerializeField] public int MaxValue { get; private set; }
    [field: SerializeField] public int Reward { get; private set; }
}