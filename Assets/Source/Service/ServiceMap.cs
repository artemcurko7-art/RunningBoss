using System.Collections;
using UnityEngine;
using Zenject;

public class ServiceMap : MonoBehaviour
{
    [SerializeField] private Map _map;
    [SerializeField] private float _delay;

    private MapPool _pool;

    private void Start()
    {
        StartCoroutine(Spawn());
        _pool.Get();
    }

    [Inject]
    public void Construct(MapPool pool)
    {
        _pool = pool;
        
        _pool.SetPrefab(_map);
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
