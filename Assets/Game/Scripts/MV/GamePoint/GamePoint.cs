using System;
using UnityEngine;

namespace Game.Scripts.MV.GamePoint
{
    public class GamePoint : IGamePoint
    {
        private int _value;

        public event Action<int> Changed;

        public int Value
        {
            get => _value;

            private set
            {
                _value = Mathf.Clamp(value, 0, int.MaxValue);
                Changed?.Invoke(_value);
            }
        }

        public void Add(int amount)
        {
            Value += amount;
        }
    }
}