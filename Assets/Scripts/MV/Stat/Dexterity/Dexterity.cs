using YG;

public class Dexterity : Stat
{
    public Dexterity(AnimalType animalType, ImprovementConfig improvementConfig, int value) : base(animalType, improvementConfig, value)
    {
        YG2.saves.ReadAnimalStatStorageData(AnimalType, StatType.Dexterity, this);
    }

    public override void Up()
    {
        base.Up();
        
        YG2.saves.WriteAnimalStatStorageData(AnimalType, StatType.Dexterity, Value, Level);
    }
}
