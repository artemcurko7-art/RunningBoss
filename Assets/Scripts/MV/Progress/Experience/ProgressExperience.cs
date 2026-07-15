using System;

public class ProgressExperience
{
    private int _value;
    private readonly int _multiplierMaxValue;
    
    public event Action<int> Changed;

    public ProgressExperience(int maxValue, int multiplierMaxValue)
    {
        MaxValue = maxValue;
        _multiplierMaxValue = multiplierMaxValue;
    }

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