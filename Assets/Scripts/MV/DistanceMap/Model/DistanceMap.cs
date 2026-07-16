using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DistanceMap : IDistanceMap, IFinished, ISubscriber
{
    private readonly CalculationDistanceMap _calculation;
    private CancellationTokenSource _cancellationTokenSource;
    private float _value;
    
    public DistanceMap(CalculationDistanceMap calculation)
    {
        _calculation = calculation;
        _value = calculation.GetDistance();
        MaxValue = _value;
    }
    
    public event Action<float> Changed;
    public event Action Finished;
    
    public float MaxValue { get; }
    public float CompletedValue => MaxValue - _value;

    public float Value
    {
        get => _value;
    
        private set
        {
            _value = Mathf.Clamp(value, 0, MaxValue);

            Changed?.Invoke(_value);
        }
    }

    public void Subscribe()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        RunAsync(_cancellationTokenSource.Token).Forget();
    }

    public void Unsubscribe()
    {
        _cancellationTokenSource.Cancel();
    }

    private async UniTaskVoid RunAsync(CancellationToken token)
    {
        while (Mathf.Approximately(_value, 0f) == false && token.IsCancellationRequested == false)
        {
            await UniTask.WaitForSeconds(0.1f, cancellationToken: token);

            if (token.IsCancellationRequested)
                return;
            
            Value = _calculation.GetDistance();
        }

        Finished?.Invoke();
    }
}