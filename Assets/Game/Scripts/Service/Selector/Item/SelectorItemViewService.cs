using Game.Scripts.Animal;
using Game.Scripts.Factories;
using Game.Scripts.Service.Inventory;
using Game.Scripts.Service.Selector.Animal;

namespace Game.Scripts.Service.Selector.Item
{
    public class SelectorItemViewService : ISubscriber
    {
        private readonly IInventoryService _inventoryService;
        private readonly IAnimalSelected _selected;
        private readonly ItemViewFactory _factory;

        public SelectorItemViewService(IInventoryService inventoryService, IAnimalSelected selected,
            ItemViewFactory factory)
        {
            _inventoryService = inventoryService;
            _selected = selected;
            _factory = factory;
        }

        public void Subscribe()
        {
            _selected.Created += OnCreated;
            _selected.Update();
        }

        public void Unsubscribe()
        {
            _selected.Created -= OnCreated;
        }

        private void OnCreated(AnimalView animalView)
        {
            foreach (var itemView in _inventoryService.FilledItemViews)
            {
                if (animalView.ItemContainer.childCount == _inventoryService.FilledItemViews.Count)
                    return;

                var value = _factory.Create(itemView, animalView.ItemContainer);
                value.gameObject.SetActive(false);
            }
        }
    }
}