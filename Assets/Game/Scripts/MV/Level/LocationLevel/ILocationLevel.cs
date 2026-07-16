using System;

public interface ILocationLevel
{
    int Value { get; }
    event Action<int> Changed;
    void Update();
}