using System;

public interface IGameLevel
{
    event Action<int> Upped;
    int Value { get; }
    void Update();
}