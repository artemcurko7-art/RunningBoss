using System;

namespace Game.Scripts.Service.Selector.Animal
{
    public interface IAnimalSelectedButton
    {
        event Action<bool> LeftSelected;
        event Action<bool> RightSelected;
        void Update();
    }
}