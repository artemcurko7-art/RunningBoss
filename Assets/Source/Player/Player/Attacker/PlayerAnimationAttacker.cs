using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAnimationAttacker
{
    private IAttacker _attacker;
    private Animator _animator;

    public PlayerAnimationAttacker(IAttacker attacker, Animator animator)
    {
        _attacker = attacker;
        _animator = animator;
    }

    public void OnEnable() =>
        _attacker.Attacked += OnAttack;

    public void OnDisable() =>
        _attacker.Attacked -= OnAttack;

    private async void OnAttack()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Attack);
    }
}