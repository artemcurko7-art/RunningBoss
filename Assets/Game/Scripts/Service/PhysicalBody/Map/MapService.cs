using System.Collections.Generic;
using Game.Scripts.MV.Level.LocationLevel;
using Game.Scripts.PoolMono.Pool;

namespace Game.Scripts.Service.PhysicalBody.Map
{
    public class MapService : IMapService
    {
        private readonly List<PoolMono.ObjectPool.Map.Map> _maps = new();

        public MapService(MapPool pool, PoolMono.ObjectPool.Map.Map[] maps, ILocationLevel locationLevel, int maxSpawned)
        {
            maxSpawned += locationLevel.Value;

            pool.SetPrefabs(maps);
            pool.SetMaxSpawned(maxSpawned);

            for (int i = 0; i <= maxSpawned; i++)
                _maps.Add(pool.Get());

            pool.Get();
        }

        public IReadOnlyList<PoolMono.ObjectPool.Map.Map> Maps => _maps;
    }
}