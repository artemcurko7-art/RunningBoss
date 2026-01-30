using UnityEngine;
using UnityEngine.Pool;

public class PoolMono <T> where T : MonoBehaviour
{
    private T _prefab;
    private ObjectPool<T> _pool;

    public void SetPrefab(T prefab)
    {
        _prefab = prefab;
    }
    
    public T Get() =>
        _pool.Get();
    
    protected void Create()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => GameObject.Instantiate(_prefab),
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