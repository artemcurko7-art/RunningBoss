using System;

namespace Game.Scripts.MV.DistanceMap.Model
{
    public interface IDistanceMap
    {
        event Action<float> Changed;
        float Value { get; }
        float CompletedValue { get; }
        float MaxValue { get; }
    }
}