using Game.Scripts.PoolMono.ObjectPool.Unit;
using UnityEngine;
using Zenject;

namespace Game.Scripts.PoolMono.Pool
{
    public class UnitPool : PoolMono<Unit>
    {
        private readonly SettingPosition.SettingPosition _settingPosition;

        private Vector3 _position;

        public UnitPool(SettingPosition.SettingPosition settingPosition, DiContainer container)
            : base(container)
        {
            _settingPosition = settingPosition;
        }

        protected override void ActionOnGet(Unit unit)
        {
            base.ActionOnGet(unit);
            unit.Disabled += OnRelease;
        }

        protected override void ActionOnRelease(Unit unit)
        {
            base.ActionOnRelease(unit);
            unit.ResetSettings();
        }

        protected override void OnRelease(Unit unit)
        {
            base.OnRelease(unit);
            unit.Disabled -= OnRelease;
        }
    }
}