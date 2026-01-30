using System.Collections.Generic;
using UnityEngine;

public class MapPool : PoolMono<Map>
{
    private readonly SettingPosition _settingPosition;
    private Vector3 _currentPosition;

    public MapPool(SettingPosition settingPosition)
    {
        _settingPosition = settingPosition;
        
        Create();
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
}