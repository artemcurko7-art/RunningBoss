using System.Collections.Generic;
using Game.Scripts.Inventory.ItemContext;
using Game.Scripts.Provider;
using UnityEngine;
using YG;

namespace Game.Scripts.Service.Inventory.ItemContext
{
    public class ItemViewService
    {
        private const float FillAmount = 1f;
        private readonly ItemViewProvider _provider;
        private readonly Queue<ItemView> _views = new();
        private readonly Queue<ItemView> _filledViews = new();

        public ItemViewService(ItemData data, ItemViewProvider provider)
        {
            _provider = provider;

            foreach (var view in data.Views.Values)
                _views.Enqueue(view);

            foreach (var type in YG2.saves.FilledItemTypes)
                _filledViews.Enqueue(_views.Dequeue());

            if (_views.Count > 0)
                _provider.Set(_views.Peek());
        }

        public IReadOnlyCollection<ItemView> FilledViews => _filledViews;

        public void CheckFullness()
        {
            if (_views.Count == 0)
                return;

            if (Mathf.Approximately(YG2.saves.InventoryItems[_views.Peek().Type], FillAmount) ||
                YG2.saves.InventoryItems[_views.Peek().Type] >= FillAmount)
            {
                var view = _views.Dequeue();
                _filledViews.Enqueue(view);
                YG2.saves.FilledItemTypes.Add(view.Type);

                if (_views.Count == 0)
                {
                    _provider.Set(null);
                    return;
                }

                _provider.Set(_views.Peek());
            }
        }
    }
}