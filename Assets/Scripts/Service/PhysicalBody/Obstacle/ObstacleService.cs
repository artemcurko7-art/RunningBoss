using UnityEngine;

public class ObstacleService : PhysicalBodyService<Obstacle>
{
    public ObstacleService(ObstaclePool pool, Obstacle[] obstacles, ILocationLevel locationLevel, ISpeed speed, IDistanceMap distanceMap, Transform player, float delay) : base(pool, locationLevel, speed, distanceMap, player, delay)
    {
        pool.SetPrefabs(obstacles);
        SetPositionY(0.5f);
    }
}