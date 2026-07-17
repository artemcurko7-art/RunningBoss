using System;
using Game.Scripts.MV.Level.GameLevel.Experience.Model;
using Game.Scripts.Service;
using YG;

namespace Game.Scripts.MV.Level.GameLevel.Level
{
    public class GameLevel : IGameLevel, ISubscriber
    {
        private readonly IGameLevelUpped _levelUpped;

        public GameLevel(IGameLevelUpped levelUpped)
        {
            _levelUpped = levelUpped;

            Value = YG2.saves.GameLevel;
        }

        public event Action<int> Upped;

        public int Value { get; private set; }

        public void Subscribe()
        {
            _levelUpped.Upped += OnUpped;
        }

        public void Unsubscribe()
        {
            _levelUpped.Upped -= OnUpped;
        }

        public void Update()
        {
            Upped?.Invoke(Value);
        }

        private void OnUpped()
        {
            Value++;
            Upped?.Invoke(Value);

            YG2.saves.GameLevel = Value;
        }
    }
}