using UnityEngine;

[CreateAssetMenu(menuName = "Source/Config/Animal/Animal", fileName = "Config", order = 1)]
public class AnimalConfig : ScriptableObject
{
    [field: SerializeField] public AnimalType Type { get; private set; }
    [field: SerializeField] public AnimalView View { get; private set; }
    [field: SerializeField] public ImprovementConfig HealthImprovement { get; private set; }
    [field: SerializeField] public ImprovementConfig ArmorImprovement { get; private set; }
    [field: SerializeField] public ImprovementConfig DexterityImprovement { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Armor { get; private set; }
    [field: SerializeField] public int Dexterity { get; private set; }
}