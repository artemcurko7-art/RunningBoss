using System.Collections.Generic;

namespace Game.Scripts.Service.PhysicalBody.Map
{
    public interface IMapService
    {
        IReadOnlyList<PoolMono.ObjectPool.Map.Map> Maps { get; }
    }
}