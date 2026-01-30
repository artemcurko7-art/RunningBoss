using UnityEngine;

public class UnitPool : PoolMono<Unit>
{
    private readonly SettingPosition _settingPosition;
    private Transform _spawn;
    
    public UnitPool(SettingPosition settingPosition)
    {
        _settingPosition = settingPosition;
        
        Create();
    }
    
    public void SetSpawn(Transform spawn)
    {
        _spawn = spawn;
    }
    
    protected override void ActionOnGet(Unit unit)
    {
        base.ActionOnGet(unit);
        unit.Initialize(_settingPosition.GetRandom(_spawn));
        unit.Died += OnRelease;
    }

    protected override void ActionOnRelease(Unit unit)
    {
        base.ActionOnRelease(unit);
        unit.ResetSettings();
    }

    protected override void OnRelease(Unit unit)
    {
        base.OnRelease(unit);
        unit.Died -= OnRelease;
    }
}