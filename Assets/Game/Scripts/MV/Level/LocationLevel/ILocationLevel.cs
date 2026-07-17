using System;

namespace Game.Scripts.MV.Level.LocationLevel
{
    public interface ILocationLevel
    {
        int Value { get; }
        event Action<int> Changed;
        void Update();
    }
}