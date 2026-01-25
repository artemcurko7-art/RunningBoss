using System;
using UnityEngine;

public class Health : IHealth
{
    private int _value;
    private int _maxValue;

    public event Action<int> Changed;

    public Health(int value)
    {
        _value = value;
        _maxValue = value;
    }

    public int Value
    {
        get => _value;

        set
        {
            _value = Math.Clamp(value, 0, _maxValue);
            Changed?.Invoke(_value);
        }
    }

    public void TakeDamage(int damage) =>
        Value -= damage;

    public void Replenish(int health) =>
        Value += health;

    public int GetMaxValue() =>
        _maxValue;
}
