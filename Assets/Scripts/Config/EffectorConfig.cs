using UnityEngine;

[CreateAssetMenu(menuName = "Source/Config/Effector", fileName = "Effector", order = 7)]
public class EffectorConfig : ScriptableObject
{
    [field: SerializeField] public EffectorType Type { get; private set; }
    [field: SerializeField] public Effector Effector { get; private set; }
}