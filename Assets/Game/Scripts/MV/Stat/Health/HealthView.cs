using UnityEngine;
using Zenject;

namespace Game.Scripts.MV.Stat.Health
{
    public abstract class HealthView : MonoBehaviour
    {
        protected IHealth Model;

        [Inject]
        public void Construct(IHealth model)
        {
            Model = model;

            Model.Changed += OnValueChanged;
            Model.Update();
        }

        private void OnDestroy()
        {
            Model.Changed -= OnValueChanged;
        }

        protected abstract void OnValueChanged(int value);
    }
}