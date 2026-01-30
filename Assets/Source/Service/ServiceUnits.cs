using System.Collections;
using UnityEngine;
using Zenject;

public class ServiceUnits : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _delay;
    
    private UnitPool _pool;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    [Inject]
    public void Construct(UnitPool pool)
    {
        _pool = pool;
        
        _pool.SetPrefab(_unit);
        _pool.SetSpawn(_spawn);
    }
    
    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            _pool.Get();

            yield return null;
        }
    }
}