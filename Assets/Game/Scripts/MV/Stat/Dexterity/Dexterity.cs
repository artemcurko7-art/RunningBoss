using Game.Scripts.Animal.Type;
using Game.Scripts.Configs;
using Game.Scripts.MVC.Stat.Type;
using YG;

namespace Game.Scripts.MV.Stat.Dexterity
{
    public class Dexterity : Stat
    {
        public Dexterity(AnimalType animalType, ImprovementConfig improvementConfig, int value)
            : base(animalType, improvementConfig, value)
        {
            YG2.saves.ReadAnimalStatStorageData(AnimalType, StatType.Dexterity, this);
        }

        public override void Up()
        {
            base.Up();

            YG2.saves.WriteAnimalStatStorageData(AnimalType, StatType.Dexterity, Value, Level);
        }
    }
}