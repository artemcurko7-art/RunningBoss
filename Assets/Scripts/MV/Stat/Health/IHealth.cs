using System;

public interface IHealth
{
    event Action<int> Changed;
    void Update();
    int MaxValue { get; }
}
