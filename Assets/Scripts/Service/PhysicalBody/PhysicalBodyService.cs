using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class PhysicalBodyService<T> : ISubscriber 
    where T : PhysicalBody<T>
{
    private const float RangeHorizontalPosition = 3.6f;
    private readonly PoolMono<T> _pool;
    private readonly ILocationLevel _locationLevel;
    private readonly ISpeed _speed;
    private readonly IDistanceMap _distanceMap;
    private readonly Transform _player;
    private CancellationTokenSource _cancellationTokenSource;
    private float _delay;
    private float _positionY;
    
    public PhysicalBodyService(PoolMono<T> pool, ILocationLevel locationLevel, ISpeed speed, IDistanceMap distanceMap, Transform player, float delay)
    {
        _pool = pool;
        _locationLevel = locationLevel;
        _speed = speed;
        _distanceMap = distanceMap;
        _player = player;
        _delay = delay;
    }
    
    public void Subscribe()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        Spawn(_cancellationTokenSource.Token).Forget();
    }

    public void Unsubscribe()
    {
        _cancellationTokenSource.Cancel();
    }

    protected void SetPositionY(float value)
    {
        _positionY = value;
    }

    protected void SetDelay(float value)
    {
        if (value < 0)
            throw new IndexOutOfRangeException(nameof(value));
        
        _delay = value;
    }
    
    private async UniTaskVoid Spawn(CancellationToken token)
    {
        while (_cancellationTokenSource.IsCancellationRequested == false)
        {
            await UniTask.WaitForSeconds(_delay, cancellationToken: token);
            
            if (GamePaused.Type == GamePausedType.Pause)
                continue;
            
            float randomPositionX = Random.Range(-RangeHorizontalPosition, RangeHorizontalPosition);
            float calculationLenght = _speed.Value * 3f;
            
            Vector3 position = new Vector3(randomPositionX, _positionY, calculationLenght + _player.position.z);
            
            if (_distanceMap.Value < calculationLenght)
                continue;

            _pool.Get().Initialize(position);
            
            await UniTask.Yield();
        }
    }
}