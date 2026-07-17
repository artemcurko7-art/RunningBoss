using Game.Scripts.Animal;

namespace Game.Scripts.Provider
{
    public interface IAnimalProvider
    {
        Animal.Animal Animal { get; }
        AnimalView AnimalView { get; }
    }
}