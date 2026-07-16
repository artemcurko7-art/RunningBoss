using System;

public interface IAnimalSelected 
{
    event Action<AnimalView> Selected;
    event Action<AnimalView> Created;
    void Update();
}