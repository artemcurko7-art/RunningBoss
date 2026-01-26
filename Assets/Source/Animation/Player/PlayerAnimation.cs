using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    public Animator Animator { get; private set; }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
}