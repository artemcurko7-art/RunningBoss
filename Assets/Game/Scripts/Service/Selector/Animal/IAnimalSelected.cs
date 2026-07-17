using System;
using Game.Scripts.Animal;

namespace Game.Scripts.Service.Selector.Animal
{
    public interface IAnimalSelected
    {
        event Action<AnimalView> Selected;
        event Action<AnimalView> Created;
        void Update();
    }
}