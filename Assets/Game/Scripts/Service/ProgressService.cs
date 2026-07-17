using Game.Scripts.Factories;
using Game.Scripts.MV.Progress.Data;
using UnityEngine;

namespace Game.Scripts.Service
{
    public class ProgressService
    {
        private readonly IProgressData _data;
        private readonly ProgressViewFactory _factory;
        private readonly RectTransform _container;

        public ProgressService(IProgressData data, ProgressViewFactory factory, RectTransform container)
        {
            _data = data;
            _factory = factory;
            _container = container;

            Fill();
        }

        private void Fill()
        {
            foreach (var progress in _data.Progresses.Values)
                _factory.Create(progress, _container);
        }
    }
}