using System.Collections.Generic;
using UnityEngine;

public class MapPool : PoolMono<Map>
{
    private Vector3 _currentPosition;

    private void Awake()
    {
        Initialize();
    }

    protected override void ActionOnGet(Map map)
    {
        base.ActionOnGet(map);
        map.Initialize(_currentPosition);
        _currentPosition = GetPosition(map);
        map.Collided += OnRelease;
    }

    protected override void ActionOnRelease(Map map)
    {
        base.ActionOnRelease(map);
        map.ResetSettings();
    }

    protected override void OnRelease(Map map)
    {
        base.OnRelease(map);
        map.Collided -= OnRelease;
    }

    private Vector3 GetPosition(Map map) =>
        map.transform.position + map.transform.forward * map.transform.localScale.z;
}
