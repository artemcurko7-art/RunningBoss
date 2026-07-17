using System;

namespace Game.Scripts.MV.Level.GameLevel.Level
{
    public interface IGameLevel
    {
        event Action<int> Upped;
        int Value { get; }
        void Update();
    }
}