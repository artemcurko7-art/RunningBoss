using System;
using YG;

namespace Game.Scripts.MV.Level.LocationLevel
{
    public class LocationLevel : ILocationLevel, ILocationLevelUpped
    {
        private int _value;

        public LocationLevel()
        {
            _value = YG2.saves.LocationLevel;
        }

        public event Action<int> Changed;

        public int Value
        {
            get => _value;

            private set
            {
                _value = Math.Clamp(value, 0, int.MaxValue);
                Changed?.Invoke(_value);

                YG2.saves.LocationLevel = _value;
            }
        }

        public void Update()
        {
            Changed?.Invoke(_value);
        }

        public void UpLevel()
        {
            Value++;
        }

        public void Reset()
        {
            Value = 0;
        }
    }
}