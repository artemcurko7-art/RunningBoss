using Game.Scripts.Animal.Type;
using Game.Scripts.Configs;
using Game.Scripts.MVC.Stat.Type;
using YG;

namespace Game.Scripts.MV.Stat.Armor
{
    public class Armor : Stat
    {
        public Armor(AnimalType animalType, ImprovementConfig improvementConfig, int value)
            : base(animalType, improvementConfig, value)
        {
            YG2.saves.ReadAnimalStatStorageData(AnimalType, StatType.Armor, this);
        }

        public override void Up()
        {
            base.Up();

            YG2.saves.WriteAnimalStatStorageData(AnimalType, StatType.Armor, Value, Level);
        }
    }
}