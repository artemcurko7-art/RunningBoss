using System;

public interface IGamePoint
{
    event Action<int> Changed;
}