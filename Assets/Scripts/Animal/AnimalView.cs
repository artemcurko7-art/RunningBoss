using UnityEngine;

public class AnimalView : MonoBehaviour
{
    [field: SerializeField] public AnimalShadow Shadow { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public SkinnedMeshRenderer SkinnedMeshRenderer { get; private set; }
    [field: SerializeField] public Transform ItemContainer { get; private set; }
    [SerializeField] private Transform _pointSpawnEffector;
    
    public Animal Animal { get; private set; }
    public Transform Effector => _pointSpawnEffector;
    public Transform Current => transform;

    public void Initialize(Animal animal)
    {
        Animal = animal;
    }

}