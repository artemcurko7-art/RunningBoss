using Game.Scripts.Animal;
using Game.Scripts.MVC.Stat.Type;
using UnityEngine;

namespace Game.Scripts.MV.Stat
{
    public class StatUppedText : StatView
    {
        [SerializeField] private NotificationStatsDisplay _notification;

        protected override void OnCreated(AnimalView view)
        {
            base.OnCreated(view);

            view.Animal.Stats[StatType.Health].Upped += OnHealthChanged;
            view.Animal.Stats[StatType.Armor].Upped += OnArmorChanged;
            view.Animal.Stats[StatType.Dexterity].Upped += OnDexterityChanged;

            _notification.Initialize(Views);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            foreach (var view in Views)
            {
                view.Animal.Stats[StatType.Health].Upped -= OnHealthChanged;
                view.Animal.Stats[StatType.Armor].Upped -= OnArmorChanged;
                view.Animal.Stats[StatType.Dexterity].Upped -= OnDexterityChanged;
            }
        }
    }
}