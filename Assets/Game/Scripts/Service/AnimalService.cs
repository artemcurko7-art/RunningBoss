using Game.Scripts.Animal.Data;
using Game.Scripts.Animal.Type;
using Game.Scripts.Service.Selector.Animal;
using YG;

namespace Game.Scripts.Service
{
    public class AnimalService
    {
        private readonly IAnimalData _dates;
        private readonly ISetterSelectorAnimalService _selector;

        public AnimalService(IAnimalData dates, ISetterSelectorAnimalService selector)
        {
            _dates = dates;
            _selector = selector;

            if (YG2.saves.AnimalTypes.Count == 0)
            {
                _selector.SetDefault(YG2.saves.DefaultSelectedAnimalType);
                YG2.saves.AnimalTypes.Add(YG2.saves.DefaultSelectedAnimalType);
            }
        }

        public void Set(AnimalType type)
        {
            var view = _dates.Views[type];

            _selector.Set(view);
            YG2.saves.AnimalTypes.Add(type);
        }
    }
}