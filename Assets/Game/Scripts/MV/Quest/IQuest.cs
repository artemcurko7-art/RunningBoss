using System;

namespace Game.Scripts.MV.Quest
{
    public interface IQuest
    {
        event Action<int> Changed;
        int MaxValue { get; }
        int Reward { get; }
    }
}