using Game.Scripts.Animal;
using Game.Scripts.MVC.Stat.Type;

namespace Game.Scripts.MV.Stat
{
    public class StatText : StatView
    {
        protected override void OnCreated(AnimalView view)
        {
            base.OnCreated(view);

            view.Animal.Stats[StatType.Health].Changed += OnHealthChanged;
            view.Animal.Stats[StatType.Armor].Changed += OnArmorChanged;
            view.Animal.Stats[StatType.Dexterity].Changed += OnDexterityChanged;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            foreach (var view in Views)
            {
                view.Animal.Stats[StatType.Health].Changed -= OnHealthChanged;
                view.Animal.Stats[StatType.Armor].Changed -= OnArmorChanged;
                view.Animal.Stats[StatType.Dexterity].Changed -= OnDexterityChanged;
            }
        }
    }
}