using System;

namespace Game.Scripts.Player.Damaged
{
    public interface IDamaged
    {
        public event Action Damaged;
    }
}