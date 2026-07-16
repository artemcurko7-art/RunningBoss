using System;
using YG;

public class Health : Stat, IHealth, IDeath, IDamaged
{
    public Health(AnimalType animalType, ImprovementConfig improvementConfig, int value) 
        : base(animalType, improvementConfig, value)
    {
        YG2.saves.ReadAnimalStatStorageData(AnimalType, StatType.Health, this);
        
        MaxValue = Value;
    }
    
    public event Action Damaged;
    public event Action Died;

    public int MaxValue { get; private set; }
    
    public void TakeDamage(int damage)
    {
        Reduce(damage);
        Damaged?.Invoke();

        if (Value <= 0)
            Died?.Invoke();
    }

    public override void Up()
    {
        base.Up();
        MaxValue = Value;
        YG2.saves.WriteAnimalStatStorageData(AnimalType, StatType.Health, Value, Level);
    }
}