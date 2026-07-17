using System;

namespace Game.Scripts.Player.Coin
{
    public class Coin
    {
        private int _value;

        public int Value
        {
            get => _value;

            private set => _value = Math.Clamp(value, 0, int.MaxValue);
        }

        public void Add(int amount)
        {
            Value += amount;
        }
    }
}