using System;

public interface IGameExperience 
{
    event Action<int, int> ValueChanged;
    void Update();
    void Add(int amount);
}