using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EffectorPool : PoolMono<Effector>
{
    private readonly List<Effector> _effectors = new();
    private Effector _effector;
    private Transform _transform;

    public EffectorPool(DiContainer container) : base(container) {}

    public void Spawn(Effector effector, Transform transform)
    {
        _effector = effector;
        _transform = transform;

        var obj = Get();
        obj.transform.SetParent(_transform);
        obj.transform.localRotation = Quaternion.identity;
    }
    
    protected override void ActionOnGet(Effector effector)
    {
        base.ActionOnGet(effector);
        effector.Initialize(_transform.position);
        effector.Disabled += OnRelease;
    }

    protected override void ActionOnRelease(Effector effector)
    {
        base.ActionOnRelease(effector);
        effector.ResetSettings();
    }

    protected override void OnRelease(Effector effector)
    {
        base.OnRelease(effector);
        effector.Disabled -= OnRelease;
    }

    protected override Effector GetRandomPrefab()
    {
        return _effector;
    }
}