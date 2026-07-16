using System.Collections.Generic;

public interface IAnimalData 
{
    IReadOnlyDictionary<AnimalType, AnimalView> Views { get; }
}