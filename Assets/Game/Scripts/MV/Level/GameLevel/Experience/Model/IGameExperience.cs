using System;

namespace Game.Scripts.MV.Level.GameLevel.Experience.Model
{
    public interface IGameExperience
    {
        event Action<int, int> ValueChanged;
        void Update();
        void Add(int amount);
    }
}