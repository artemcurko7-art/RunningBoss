using System;

public interface ISkillPoint 
{
    event Action<int> Changed;
    void Update();
    int Value { get; }
}