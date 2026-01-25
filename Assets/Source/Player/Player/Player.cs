using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable, IAttacker
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private HandlerTouch _handlerTouch;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _forwardPowerThrow;
    [SerializeField] private float _upPowerThrow;

    private IHealthPresenter _healthPresenter;
    private PlayerMover _mover;
    private Animator _animator;

    public event Action Attacked;

    private void Update()
    {
        _mover.Move(Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            other.GetComponent<Collider>().enabled = false;
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.transform.GetChild(1).gameObject.SetActive(true);

            var rigidbodyes = other.transform.GetComponentsInChildren<Rigidbody>();

            foreach (var rigidbody in rigidbodyes)
            {
                rigidbody.AddForce(transform.forward * _forwardPowerThrow, ForceMode.Impulse);
                rigidbody.AddForce(transform.up * _upPowerThrow, ForceMode.Impulse);
            }

            Attack(damagable);

            Debug.Log("Не сколько раз");
        }
    }

    public void Initialize(IHealthPresenter healthPresenter, Animator animator)
    {
        _mover = new PlayerMover(transform, _movementSpeed);
        _healthPresenter = healthPresenter;
        _animator = animator;
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, true);
    }

    public void Attack(IDamagable damagable)
    {
        damagable.TakeDamage();
        Attacked?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _healthPresenter.TakeDamage(damage);
    }
}