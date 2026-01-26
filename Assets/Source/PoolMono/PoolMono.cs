using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolMono <T>: MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;

    public T Get() =>
        _pool.Get();

    protected void Initialize()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (prefab) => ActionOnGet(prefab),
            actionOnRelease: (prefab) => ActionOnRelease(prefab));
    }

    protected virtual void ActionOnGet(T prefab) =>
        prefab.gameObject.SetActive(true);

    protected virtual void ActionOnRelease(T prefab) =>
        prefab.gameObject.SetActive(false);

    protected virtual void OnRelease(T prefab) =>
        _pool.Release(prefab);
}
