using System;

namespace Game.Scripts.Menu.Game
{
    public interface IGame
    {
        event Action Paused;
        event Action Resumed;
        event Action Ended;
    }
}