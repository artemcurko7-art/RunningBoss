using Zenject;

public class ObstaclePool : PoolMono<Obstacle>
{
    public ObstaclePool(DiContainer container) 
        : base(container) { }
    
    protected override void ActionOnGet(Obstacle obstacle)
    {
        base.ActionOnGet(obstacle);
        obstacle.Disabled += OnRelease;
    }

    protected override void ActionOnRelease(Obstacle obstacle)
    {
        base.ActionOnRelease(obstacle); 
        obstacle.ResetSettings();
    }

    protected override void OnRelease(Obstacle obstacle)
    {
        base.OnRelease(obstacle);
        obstacle.Disabled -= OnRelease;
    }
}
