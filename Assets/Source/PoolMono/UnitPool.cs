using System.Collections.Generic;
using UnityEngine;

public class UnitPool : PoolMono<Unit>
{
    [SerializeField] private Transform _parentSpawn;

    private RandomPosition _randomPosition;

    private void Awake()
    {
        _randomPosition = new RandomPosition();
        Initialize();
    }

    protected override void ActionOnGet(Unit unit)
    {
        base.ActionOnGet(unit);
        unit.Initialize(_randomPosition.Get(_parentSpawn));
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
