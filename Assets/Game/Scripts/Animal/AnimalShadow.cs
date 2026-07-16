using UnityEngine;

public class AnimalShadow : MonoBehaviour
{
    public Animator Animator { get; private set; }
    
    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
}