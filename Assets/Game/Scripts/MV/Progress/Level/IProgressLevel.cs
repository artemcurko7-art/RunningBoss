using System;

public interface IProgressLevel
{
    event Action<int> Upped;
    int Value { get; }
}