using System;
using UnityEngine;
using YG;

public class GameExperience : IGameExperience, IGameLevelUpped
{
    private const float Delay = 1;
    private readonly ExperienceStats _stats;
    private int _value;
    private int _maxValue;
    
    public GameExperience(ExperienceStats stats)
    {
        _stats = stats;
        
        _maxValue = YG2.saves.GameExperienceMaxValue;
        Value = YG2.saves.GameExperienceValue;
    }
    
    public event Action<int, int> ValueChanged;
    public event Action Upped;
    
    public int Value
    {
        get => _value;

        private set
        {
            _value = Mathf.Clamp(value, 0, int.MaxValue);
            ValueChanged?.Invoke(_value, _maxValue);
            
            YG2.saves.GameExperienceValue = Value;
            YG2.saves.GameExperienceMaxValue = _maxValue;
        }
    }
    
    public void Update()
    {
        ValueChanged?.Invoke(_value, _maxValue);
    }
    
    public void Add(int amount)
    {
        Value += amount;

        while (Value >= _maxValue)
            UpLevel();
    }

    private void UpLevel()
    {
        var calculation = Value - _maxValue;
        _maxValue *= _stats.MultiplierMaxValue;
        Value = 0;
        Value += calculation;
        ValueChanged?.Invoke(_value, _maxValue);
        Upped?.Invoke();
    }
}