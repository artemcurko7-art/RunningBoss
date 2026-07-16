using DG.Tweening;
using UnityEngine;

public class ShakingCameraDamaged : DamagedSubscriber
{
    private readonly Camera _mainCamera;
    private Tween _tween;
    
    public ShakingCameraDamaged(IDamaged damaged, Camera mainCamera)
        : base(damaged)
    {
        _mainCamera = mainCamera;
    }

    protected override void OnDamaged()
    {
        _tween?.Kill(true);
        _tween = _mainCamera.DOShakePosition(0.2f, 1);
    }
}