using UnityEngine;
using Zenject;

public class UnitPool : PoolMono<Unit>
{
    private readonly SettingPosition _settingPosition;
    
    private Vector3 _position;
    
    public UnitPool(SettingPosition settingPosition, DiContainer container)
        : base(container)
    {
        _settingPosition = settingPosition;
    }
    
    protected override void ActionOnGet(Unit unit)
    {
        base.ActionOnGet(unit);
        unit.Disabled += OnRelease;
    }

    protected override void ActionOnRelease(Unit unit)
    {
        base.ActionOnRelease(unit);
        unit.ResetSettings();
    }

    protected override void OnRelease(Unit unit)
    {
        base.OnRelease(unit);
        unit.Disabled -= OnRelease;
    }
}