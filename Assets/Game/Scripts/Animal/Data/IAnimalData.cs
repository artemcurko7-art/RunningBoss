using Game.Scripts.Animal.Type;
using System.Collections.Generic;

namespace Game.Scripts.Animal.Data
{
    public interface IAnimalData 
    {
        IReadOnlyDictionary<AnimalType, AnimalView> Views { get; }
    }
}