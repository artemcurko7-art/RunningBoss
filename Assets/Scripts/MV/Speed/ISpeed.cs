using System;

public interface ISpeed
{
    float Value { get; }
    event Action<float> Changed;
}