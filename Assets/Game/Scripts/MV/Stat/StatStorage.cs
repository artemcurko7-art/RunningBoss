using Game.Scripts.Animal.Type;
using Game.Scripts.MV.Stat;
using Game.Scripts.MVC.Stat.Type;
using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG 
    {
        public Dictionary<AnimalType, Dictionary<StatType, StatStorageData>> AnimalStats = new ();

        public void AddAnimalStat(AnimalType animalType, StatType statType)
        {
            if (AnimalStats.ContainsKey(animalType) == false)
                AnimalStats.Add(animalType, new Dictionary<StatType, StatStorageData>());

            if (AnimalStats[animalType].ContainsKey(statType) == false)
                AnimalStats[animalType].Add(statType, new StatStorageData());
        }

        public void WriteAnimalStatStorageData(AnimalType animalType, StatType statType, int value, int level)
        {
            AnimalStats[animalType][statType].Value = value;
            AnimalStats[animalType][statType].Level = level;
        }
        
        public void ReadAnimalStatStorageData(AnimalType animalType, StatType statType, Stat animalStat)
        {
            if (AnimalStats.ContainsKey(animalType) == false)
                return;
            
            if (AnimalStats[animalType].ContainsKey(statType) == false)
                return;
            
            if (AnimalStats[animalType][statType].Value == 0 || AnimalStats[animalType][statType].Level == 0)
                return;
            
            animalStat.SetValue(AnimalStats[animalType][statType].Value);
            animalStat.SetLevel(AnimalStats[animalType][statType].Level);
        }
    }
}