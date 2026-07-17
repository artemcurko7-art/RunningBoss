using System.Collections.Generic;
using Game.Scripts.Factories;
using Game.Scripts.Inventory.ItemContext;
using Game.Scripts.Service.Inventory.ItemContext;
using UnityEngine;

namespace Game.Scripts.Service.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly List<ItemCell> _cells = new();
        private readonly ItemData _data;
        private readonly ItemCellFactory _factory;
        private readonly RectTransform _container;

        public InventoryService(ItemData data, ItemViewService itemViewService, ItemCellFactory factory,
            RectTransform container)
        {
            _data = data;
            _factory = factory;
            _container = container;

            FilledItemViews = new List<ItemView>(itemViewService.FilledViews);

            Fill();
        }

        public IReadOnlyList<ItemCell> Cells => _cells;
        public IReadOnlyList<ItemView> FilledItemViews { get; }

        private void Fill()
        {
            foreach (var config in _data.Configs.Values)
            {
                var cell = _factory.Create(config, _container, _data.Views[config.Type].Item.DegreeOfOccupancy);
                _cells.Add(cell);
            }
        }
    }
}