using System.Collections;
using UnityEngine;

public class SpawnerUnit : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
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