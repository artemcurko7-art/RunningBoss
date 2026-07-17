using System;

namespace Game.Scripts.MV.GamePoint
{
    public interface IGamePoint
    {
        event Action<int> Changed;
    }
}