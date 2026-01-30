using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    private IHealthPresenter _healthPresenter;
    private MoverForward _mover;
    private Animator _animator;
    private float _movementForwardSpeed;
    
    private void Start()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, true);
    }

    private void Update()
    {
        _mover.Move(transform, Vector3.forward, _movementForwardSpeed);
    }
    
    public void Initialize(MoverForward mover, IHealthPresenter healthPresenter, Animator animator, float movementForwardSpeed)
    {
        _mover = mover;
        _healthPresenter = healthPresenter;
        _animator = animator;
        _movementForwardSpeed = movementForwardSpeed;
    }
    
    public void TakeDamage(int damage)
    {
        _healthPresenter.TakeDamage(damage);
    }
}