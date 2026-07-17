using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PoolMono.Pool
{
    public class EffectorPool : PoolMono<Effector.Effector>
    {
        private readonly List<Effector.Effector> _effectors = new();
        private Effector.Effector _effector;
        private Transform _transform;

        public EffectorPool(DiContainer container)
            : base(container)
        {
        }

        public void Spawn(Effector.Effector effector, Transform transform)
        {
            _effector = effector;
            _transform = transform;

            var obj = Get();
            obj.transform.SetParent(_transform);
            obj.transform.localRotation = Quaternion.identity;
        }

        protected override void ActionOnGet(Effector.Effector effector)
        {
            base.ActionOnGet(effector);
            effector.Initialize(_transform.position);
            effector.Disabled += OnRelease;
        }

        protected override void ActionOnRelease(Effector.Effector effector)
        {
            base.ActionOnRelease(effector);
            effector.ResetSettings();
        }

        protected override void OnRelease(Effector.Effector effector)
        {
            base.OnRelease(effector);
            effector.Disabled -= OnRelease;
        }

        protected override Effector.Effector GetRandomPrefab()
        {
            return _effector;
        }
    }
}