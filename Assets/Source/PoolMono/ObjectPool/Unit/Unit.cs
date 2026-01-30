using System;
using System.Collections;
using UnityEngine;

public class Unit : PhysicalBody, IInteractable
{
    [SerializeField] private int _damage;
    
    private const int IndexUnitLife = 0;
    private const int IndexUnitDeath = 1;
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
 
    public override void ResetSettings()
    {
        base.ResetSettings();
        _collider.enabled = true;
        transform.GetChild(IndexUnitLife).gameObject.SetActive(true);
        transform.GetChild(IndexUnitDeath).gameObject.SetActive(false);
    }

    public Transform GetTransform() =>
        transform;
    
    private void Attack(IDamagable damagable) =>
        damagable.TakeDamage(_damage);

    protected override IEnumerator StartWaitAddingToPool()
    {
        yield return new WaitForSeconds(StartWait);    
        
        Died?.Invoke(this);
    }
}