public class SlowingSpeedDamaged : DamagedSubscriber
{
    private readonly Speed _speed;
    
    public SlowingSpeedDamaged(IDamaged damaged, Speed speed) 
        : base(damaged)
    {
        _speed = speed;
    }

    protected override void OnDamaged()
    {
        _speed.Slow();
    }
}
