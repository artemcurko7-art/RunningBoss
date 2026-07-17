using Game.Scripts.Animal;
using Game.Scripts.Animal.Type;

namespace Game.Scripts.Service.Selector.Animal
{
    public interface ISetterSelectorAnimalService
    {
        void Set(AnimalView prefab);
        void SetDefault(AnimalType type);
    }
}