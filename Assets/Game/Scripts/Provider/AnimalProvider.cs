public class AnimalProvider : IAnimalProvider
{
    public AnimalView AnimalView { get; private set; }
    public Animal Animal { get; private set; }
    
    public void Set(AnimalView animalView, Animal animal)
    {
        AnimalView = animalView;
        Animal = animal;
    }
}