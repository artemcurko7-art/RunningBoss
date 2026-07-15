using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class MapPool : PoolMono<Map>
{
    private readonly SettingPosition _settingPosition;
    private Vector3 _currentPosition;
    private int _maxSpawned;

    public MapPool(SettingPosition settingPosition, DiContainer container) : base(container)
    {
        _settingPosition = settingPosition;
    }

    public void SetMaxSpawned(int maxSpawned)
    {
        if (maxSpawned < 0)
            throw new IndexOutOfRangeException("maxSpawned cannot be less than 0");
        
        _maxSpawned = maxSpawned;
    }
    
    protected override void ActionOnGet(Map map)
    {
        base.ActionOnGet(map);
        map.Initialize(_currentPosition);
        _currentPosition = _settingPosition.GetCalculationOnLength(map.transform);
        map.Disabled += OnRelease;
    }

    protected override void ActionOnRelease(Map map)
    {
        base.ActionOnRelease(map);
        map.ResetSettings();
    }

    protected override void OnRelease(Map map)
    {
        base.OnRelease(map);
        map.Disabled -= OnRelease;
    }

    protected override Map GetRandomPrefab()
    {
        int index = 0;
        
        if (Pool.CountAll > 0)
            index = Random.Range(1, Prefabs.Length - 1);
        
        if (Pool.CountAll == _maxSpawned)
            index = Prefabs.Length - 1;

        return Prefabs[index];
    }
}