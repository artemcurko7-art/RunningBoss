using UnityEngine;
using Zenject;

public class ServiceAttacker : MonoBehaviour
{
    private PlayerRagdollOperations _operations;
    private PlayerAnimationAttacker _animationAttacker;
    
    [Inject]
    public void Construct(PlayerRagdollOperations operations, PlayerAnimationAttacker animationAttacker)
    {
        _operations = operations;
        _animationAttacker = animationAttacker;
    }

    private void OnEnable()
    {
        _operations.OnEnable();
        _animationAttacker.OnEnable();
    }

    private void OnDisable()
    {
        _operations.OnDisable();
        _animationAttacker.OnDisable();
    }
}
