using System;

namespace Game.Scripts.MV.Progress.Level
{
    public interface IProgressLevel
    {
        event Action<int> Upped;
        int Value { get; }
    }
}