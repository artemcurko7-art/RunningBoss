using System;
using System.Collections.Generic;

namespace Game.Scripts.MV.Progress.Reward
{
    public interface IProgressReward
    {
        event Action<List<int>> Rewarded;
        List<int> Rewards { get; }
        int Value { get; }
        int GetValueRemoved();
    }
}