using System;
using UnityEngine;
using YG;

public class SkillPoint : ISkillPoint, ISubscriber
{
    private readonly IGameLevelUpped _levelUpped;
    private int _value;
    
    public event Action<int> Changed;
    
    public SkillPoint(IGameLevelUpped levelUpped)
    {
        _levelUpped = levelUpped;
        Value = YG2.saves.SkillPoint;
    }

    public int Value
    {
        get => _value;

        private set
        {
            _value = Mathf.Clamp(value, 0, int.MaxValue);
            Changed?.Invoke(Value);
            
            YG2.saves.SkillPoint = _value;
        }
    }

    public void Subscribe()
    {
        _levelUpped.Upped += OnLevelUpped;
    }

    public void Unsubscribe()
    {
        _levelUpped.Upped -= OnLevelUpped;
    }

    public void Update()
    {
        Changed?.Invoke(Value);
    }

    public void Reduce()
    {
        Value--;
    }
    
    private void OnLevelUpped()
    {
        Value++;
    }
}