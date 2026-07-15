using System;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Random = UnityEngine.Random;

public abstract class PoolMono <T> where T : PhysicalBody<T>
{
    private readonly DiContainer _container;
    private int _value;

    public PoolMono(DiContainer container)
    {
        _container = container;
        
        Create();
    }
    
    protected ObjectPool<T> Pool { get; private set; }
    protected T[] Prefabs { get; private set; }

    public void SetPrefabs(T[] prefabs)
    {
        Prefabs = prefabs ?? throw new ArgumentNullException(nameof(prefabs));
    }
    
    public T Get() =>
        Pool.Get();
    
    protected virtual void ActionOnGet(T prefab) =>
        prefab.gameObject.SetActive(true);

    protected virtual void ActionOnRelease(T prefab) =>
        prefab.gameObject.SetActive(false);

    protected virtual void OnRelease(T prefab) =>
        Pool.Release(prefab);

    protected virtual T GetRandomPrefab()
    {
        return Prefabs[Random.Range(0, Prefabs.Length)];
    }
    
    private void Create()
    {
        Pool = new ObjectPool<T>(
                createFunc: () => 
                GameObject.Instantiate(GetRandomPrefab(), Vector3.zero, Quaternion.identity),
                actionOnGet: (prefab) => ActionOnGet(prefab),
                actionOnRelease: (prefab) => ActionOnRelease(prefab));
    }
}