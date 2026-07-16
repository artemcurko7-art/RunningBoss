using System;

public interface IHealth
{
    event Action<int> Changed;
    int MaxValue { get; }
    void Update();
}
