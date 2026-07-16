using System.Collections.Generic;

public class MapService : IMapService
{
    private readonly List<Map> _maps = new ();
    
    public MapService(MapPool pool, Map[] maps, ILocationLevel locationLevel, int maxSpawned)
    {
        maxSpawned += locationLevel.Value;
        
        pool.SetPrefabs(maps);
        pool.SetMaxSpawned(maxSpawned);

        for (int i = 0; i <= maxSpawned; i++)
            _maps.Add(pool.Get());

        pool.Get();
    }
    
    public IReadOnlyList<Map> Maps => _maps;
}