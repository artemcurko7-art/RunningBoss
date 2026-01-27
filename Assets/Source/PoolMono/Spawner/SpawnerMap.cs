using System.Collections;
using UnityEngine;

public class SpawnerMap : MonoBehaviour
{
    [SerializeField] private MapPool _pool;
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
