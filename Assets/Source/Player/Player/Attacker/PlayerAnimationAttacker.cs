using System.Collections;
using UnityEngine;

public class PlayerAnimationAttacker
{
    private IAttacker _attacker;
    private Animator _animator;

    public PlayerAnimationAttacker(IAttacker attack, Animator animator)
    {
        _attacker = attack;
        _animator = animator;
    }

    public void OnEnable() =>
        _attacker.Attacked += OnAttack;

    public void OnDisable() =>
        _attacker.Attacked -= OnAttack;

    private void OnAttack()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Attack);
        //_animator.ResetTrigger(PlayerAnimatorData.Params.Attack);
    }
}