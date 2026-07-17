using System;

namespace Game.Scripts.MV.Progress.Experience
{
    public class ProgressExperience
    {
        private readonly int _multiplierMaxValue;
        private int _value;

        public ProgressExperience(int maxValue, int multiplierMaxValue)
        {
            MaxValue = maxValue;
            _multiplierMaxValue = multiplierMaxValue;
        }

        public event Action<int> Changed;

        public int MaxValue { get; private set; }

        public int Value
        {
            get => _value;

            private set
            {
                _value = Math.Clamp(value, 0, int.MaxValue);
                Changed?.Invoke(_value);
            }
        }

        public void Update()
        {
            Changed?.Invoke(Value);
        }

        public void Add(int value)
        {
            Value += value;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetMaxValue(int maxValue)
        {
            MaxValue = maxValue;
        }

        public void UpMultiplerValue()
        {
            MaxValue *= _multiplierMaxValue;
            Update();
        }
    }
}