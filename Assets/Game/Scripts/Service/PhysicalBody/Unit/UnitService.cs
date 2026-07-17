using Game.Scripts.MV.DistanceMap.Model;
using Game.Scripts.MV.Level.LocationLevel;
using Game.Scripts.MV.Speed;
using Game.Scripts.PoolMono.Pool;
using UnityEngine;

namespace Game.Scripts.Service.PhysicalBody.Unit
{
    public class UnitService : PhysicalBodyService<PoolMono.ObjectPool.Unit.Unit>
    {
        private readonly ILocationLevel _locationLevel;
        private float _delay;

        public UnitService(UnitPool pool, PoolMono.ObjectPool.Unit.Unit[] units, ILocationLevel locationLevel, ISpeed speed,
            IDistanceMap distanceMap, Transform player, float delay)
            : base(pool, locationLevel, speed, distanceMap, player, delay)
        {
            _locationLevel = locationLevel;
            _delay = delay;

            pool.SetPrefabs(units);
            SetPositionY(0.376f);
            SetDelay(GetCalculationDelay());
        }

        private float GetCalculationDelay()
        {
            for (int i = 0; i < _locationLevel.Value; i++)
                _delay -= 0.2f;

            if (_delay <= 0.5f)
                _delay = 0.5f;

            return _delay;
        }
    }
}