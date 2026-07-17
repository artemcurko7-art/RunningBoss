using Game.Scripts.Animal.Type;
using Game.Scripts.Inventory.ItemContext;
using Game.Scripts.MV.Stat;
using Game.Scripts.MV.Stat.Armor;
using Game.Scripts.MV.Stat.Dexterity;
using Game.Scripts.MV.Stat.Health;
using Game.Scripts.MVC.Stat.Type;
using System.Collections.Generic;
using YG;

namespace Game.Scripts.Animal
{
    public class Animal
    {
        private readonly Dictionary<StatType, Stat> _stats = new();

        public Animal(AnimalType type, Health health, Armor armor, Dexterity dexterity)
        {
            Type = type;

            _stats.Add(StatType.Health, health);
            _stats.Add(StatType.Armor, armor);
            _stats.Add(StatType.Dexterity, dexterity);

            foreach (var stat in _stats)
                YG2.saves.AddAnimalStat(Type, stat.Key);
        }

        public AnimalType Type { get; }
        public ItemView ItemView { get; private set; }
        public IReadOnlyDictionary<StatType, Stat> Stats => _stats;

        public void SetItem(ItemView itemView)
        {
            ItemView = itemView;
        }
    }
}