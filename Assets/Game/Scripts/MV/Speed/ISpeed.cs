using System;

public interface ISpeed
{
    event Action<float> Changed;
    float Value { get; }
}