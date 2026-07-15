using System;
using System.Collections.Generic;

public class ProgressReward : IProgressReward
{
    private List<int> _rewards = new();
    private readonly int _multiplierValue;
    
    public event Action<List<int>> Rewarded;
    
    public ProgressReward(int reward, int multiplierValue)
    {
        Value = reward;
        _multiplierValue = multiplierValue;
    }

    public List<int> Rewards => _rewards;
    public int Value { get; private set; }

    public void Add(int value)
    {
        _rewards.Add(value);
        Rewarded?.Invoke(_rewards);
    }

    public int GetValueRemoved()
    {
        int value = _rewards[^1];
        _rewards.Remove(value);
        Rewarded?.Invoke(_rewards);
        
        return value;
    }

    public void Update()
    {
        Rewarded?.Invoke(_rewards);
    }

    public void UpMultiplerValue()
    {
        Value *= _multiplierValue;
    }
    
    public void SetValue(List<int> rewards)
    {
        _rewards = rewards;
        Rewarded?.Invoke(_rewards);
    }
}