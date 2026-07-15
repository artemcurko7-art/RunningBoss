using System;

public interface IGame
{
    event Action Paused;
    event Action Resumed;
    event Action Ended;
}
