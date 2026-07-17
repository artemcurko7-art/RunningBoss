using Game.Scripts.MV.Progress;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Factories
{
    public class ProgressViewFactory
    {
        private readonly ProgressView _view;
        private readonly DiContainer _container;

        public ProgressViewFactory(ProgressView view, DiContainer container)
        {
            _view = view;
            _container = container;
        }

        public ProgressView Create(Progress progress, RectTransform container)
        {
            var view = _container.InstantiatePrefabForComponent<ProgressView>(_view, container.position,
                Quaternion.identity, container);
            view.Initialize(progress);

            return view;
        }
    }
}