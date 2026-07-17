using System;

namespace Game.Scripts.Player.Death
{
    public interface IDeath
    {
        event Action Died;
    }
}