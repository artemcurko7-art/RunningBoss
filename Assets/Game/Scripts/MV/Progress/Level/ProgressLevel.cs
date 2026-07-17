using System;

namespace Game.Scripts.MV.Progress.Level
{
    public class ProgressLevel : IProgressLevel
    {
        private int _value;

        public event Action<int> Upped;

        public int MaxValue { get; private set; } = 5;

        public int Value
        {
            get => _value;

            private set
            {
                _value = Math.Clamp(value, 0, MaxValue);
                Upped?.Invoke(_value);
            }
        }

        public void Initialize(int maxValue)
        {
            MaxValue = maxValue;
        }

        public void Update()
        {
            Upped?.Invoke(Value);
        }

        public void Up()
        {
            Value++;
        }

        public void SetValue(int value)
        {
            Value = value;
        }
    }
}