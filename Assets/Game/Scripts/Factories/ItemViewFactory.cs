using Game.Scripts.Inventory.ItemContext;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class ItemViewFactory
    {
        private readonly DiContainer _container;

        public ItemViewFactory(DiContainer container)
        {
            _container = container;
        }

        public ItemView Create(ItemView itemView, Transform container)
        {
            var view = _container.InstantiatePrefabForComponent<ItemView>(itemView, container.position,
                Quaternion.identity, container);
            view.transform.localPosition = Vector3.zero;
            view.transform.localRotation = Quaternion.identity;
            view.transform.localScale *= container.localScale.x;

            return view;
        }
    }
}