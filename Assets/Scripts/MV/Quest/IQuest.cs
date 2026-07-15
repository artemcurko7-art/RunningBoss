using System;

public interface IQuest
{
    event Action<int> Changed;
    int MaxValue { get; }
    int Reward { get; }
}
