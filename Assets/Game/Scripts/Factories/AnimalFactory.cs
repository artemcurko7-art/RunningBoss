using Game.Scripts.Configs;
using Game.Scripts.MV.Stat.Armor;
using Game.Scripts.MV.Stat.Dexterity;
using Game.Scripts.MV.Stat.Health;

namespace Game.Scripts.Factories
{
    public class AnimalFactory
    {
        public Animal.Animal Create(AnimalConfig config)
        {
            var health = new Health(config.Type, config.HealthImprovement, config.Health);
            var armor = new Armor(config.Type, config.ArmorImprovement, config.Armor);
            var dexterity = new Dexterity(config.Type, config.DexterityImprovement, config.Dexterity);

            var animal = new Animal.Animal(config.Type, health, armor, dexterity);

            return animal;
        }
    }
}