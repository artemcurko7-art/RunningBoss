using System;

public interface IDistanceMap 
{
    event Action<float> Changed;
    float Value { get; }
    float CompletedValue { get; }
    float MaxValue { get; }
}