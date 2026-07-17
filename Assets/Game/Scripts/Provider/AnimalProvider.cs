using Game.Scripts.Animal;

namespace Game.Scripts.Provider
{
    public class AnimalProvider : IAnimalProvider
    {
        public AnimalView AnimalView { get; private set; }
        public Animal.Animal Animal { get; private set; }

        public void Set(AnimalView animalView, Animal.Animal animal)
        {
            AnimalView = animalView;
            Animal = animal;
        }
    }
}