using Game.Scripts.MV.DistanceMap.Model;
using Game.Scripts.MV.Level.LocationLevel;
using Game.Scripts.MV.Speed;
using Game.Scripts.PoolMono.Pool;
using UnityEngine;

namespace Game.Scripts.Service.PhysicalBody.Obstacle
{
    public class ObstacleService : PhysicalBodyService<PoolMono.ObjectPool.Obstacle.Obstacle>
    {
        public ObstacleService(ObstaclePool pool, PoolMono.ObjectPool.Obstacle.Obstacle[] obstacles, ILocationLevel locationLevel, ISpeed speed,
            IDistanceMap distanceMap, Transform player, float delay)
            : base(pool, locationLevel, speed, distanceMap, player, delay)
        {
            pool.SetPrefabs(obstacles);
            SetPositionY(0.5f);
        }
    }
}