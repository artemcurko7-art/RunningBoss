using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolMono <T>: MonoBehaviour where T : MonoBehaviour
{
    [field: SerializeField] protected T Prefab { get; private set; }

    protected ObjectPool<T> Pool { get; private set; }

    public T Get() =>
        Pool.Get();

    protected void Initialize()
    {
        Pool = new ObjectPool<T>(
            createFunc: () => Instantiate(Prefab),
            actionOnGet: (prefab) => ActionOnGet(prefab),
            actionOnRelease: (prefab) => ActionOnRelease(prefab));
    }

    protected virtual void ActionOnGet(T prefab) =>
        prefab.gameObject.SetActive(true);

    protected virtual void ActionOnRelease(T prefab) =>
        prefab.gameObject.SetActive(false);

    protected virtual void OnRelease(T prefab) =>
        Pool.Release(prefab);
}