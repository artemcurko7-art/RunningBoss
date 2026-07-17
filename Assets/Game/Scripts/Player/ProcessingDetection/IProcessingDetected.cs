using System;
using Game.Scripts.PoolMono.ObjectPool.Unit;

namespace Game.Scripts.Player.ProcessingDetection
{
    public interface IProcessingDetected
    {
        event Action<Unit> Detected;
    }
}