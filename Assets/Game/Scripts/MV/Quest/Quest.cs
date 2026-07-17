using Game.Scripts.Configs;
using System;
using UnityEngine;

namespace Game.Scripts.MV.Quest
{
    public class Quest : IQuest
    {
        private int _value;

        public Quest(QuestConfig config)
        {
            Config = config;
            MaxValue = Config.MaxValue;
            Reward = Config.Reward;
        }

        public event Action<int> Changed;

        public int Value
        {
            get => _value;

            private set
            {
                _value = Mathf.Clamp(value, 0, MaxValue);
                Changed?.Invoke(_value);
            }
        }

        public QuestConfig Config { get; }
        public int MaxValue { get; }
        public int Reward { get; private set; }
        public bool IsCompleted => Value == MaxValue;

        public void Update()
        {
            Changed?.Invoke(_value);
        }

        public void Add(int amount)
        {
            Value += amount;
        }

        public int GetReward()
        {
            var value = Reward;
            Reward = 0;

            return value;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetReward(int reward)
        {
            Reward = reward;
        }
    }
}