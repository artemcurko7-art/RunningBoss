using UnityEngine;

public class PlayerAnimationAttacker
{
    private readonly IAttacker _attacker;
    private readonly Animator _animator;
    
    public PlayerAnimationAttacker(IAttacker attacker, Animator animator)
    {
        _attacker = attacker;
        _animator = animator;
    }

    public void OnEnable() =>
        _attacker.Attacked += OnAttack;
    
    public void OnDisable() =>
        _attacker.Attacked -= OnAttack;
    
    public void OnAttack()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Attack);
    }
}