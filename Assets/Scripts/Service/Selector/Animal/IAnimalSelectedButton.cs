using System;

public interface IAnimalSelectedButton
{
    event Action<bool> LeftSelected;
    event Action<bool> RightSelected;
    void Update();
}