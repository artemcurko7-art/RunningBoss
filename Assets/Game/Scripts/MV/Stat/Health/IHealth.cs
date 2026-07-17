using System;

namespace Game.Scripts.MV.Stat.Health
{
    public interface IHealth
    {
        event Action<int> Changed;
        int MaxValue { get; }
        void Update();
    }
}