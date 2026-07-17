using System;

namespace Game.Scripts.MV.Speed
{
    public interface ISpeed
    {
        event Action<float> Changed;
        float Value { get; }
    }
}