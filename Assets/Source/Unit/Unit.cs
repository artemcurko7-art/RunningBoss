using System;
using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour, IInteractable
{
    [SerializeField] private int _damage;
    [SerializeField] private float _startWaitAddingToPool;

    private Collider _collider;

    public event Action<Unit> Died;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            Attack(damagable);
        }
    }

    public void Initialize(Vector3 position)
    {
        transform.position = position;
        StartCoroutine(StartWaitAddingToPool());
    }

    public void ResetSettings()
    {
        transform.position = Vector3.zero;
        _collider.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    private void Attack(IDamagable damagable) =>
        damagable.TakeDamage(_damage);

    private IEnumerator StartWaitAddingToPool()
    {
        yield return new WaitForSeconds(_startWaitAddingToPool);

        Died?.Invoke(this);
    }
}