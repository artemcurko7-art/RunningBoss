using Game.Scripts.Animal;
using Game.Scripts.Service.Selector.Animal;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.MV.Stat
{
    public abstract class StatView : MonoBehaviour
    {
        private readonly List<AnimalView> _views = new();

        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _armorText;
        [SerializeField] private TMP_Text _dexterityText;

        private IAnimalSelected _selected;

        protected IReadOnlyList<AnimalView> Views => _views;

        [Inject]
        public void Construct(IAnimalSelected selected)
        {
            _selected = selected;

            _selected.Created += OnCreated;
            _selected.Selected += OnSelected;
            _selected.Update();
        }

        protected virtual void OnDestroy()
        {
            _selected.Created -= OnCreated;
            _selected.Selected -= OnSelected;
        }

        protected virtual void OnCreated(AnimalView view)
        {
            _views.Add(view);
        }

        protected void OnHealthChanged(int value)
        {
            _healthText.text = value.ToString();
        }

        protected void OnArmorChanged(int value)
        {
            _armorText.text = value.ToString();
        }

        protected void OnDexterityChanged(int value)
        {
            _dexterityText.text = value.ToString();
        }

        private void OnSelected(AnimalView view)
        {
            foreach (var improvement in view.Animal.Stats.Values)
                improvement.Update();
        }
    }
}