using Game.Scripts.Effector.Type;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Source/Config/Effector", fileName = "Effector", order = 7)]
    public class EffectorConfig : ScriptableObject
    {
        [field: SerializeField] public EffectorType Type { get; private set; }
        [field: SerializeField] public Effector.Effector Effector { get; private set; }
    }
}