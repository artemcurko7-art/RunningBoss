using System;

public interface IGameLevel
{
    int Value { get; }
    event Action<int> Upped;
    void Update();
}
