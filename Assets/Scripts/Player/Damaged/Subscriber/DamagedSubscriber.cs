public abstract class DamagedSubscriber : ISubscriber
{
    private readonly IDamaged _damaged;
    
    public DamagedSubscriber(IDamaged damaged)
    {
        _damaged = damaged;
    }
    
    public virtual void Subscribe()
    {
        _damaged.Damaged += OnDamaged;
    }

    public virtual void Unsubscribe()
    {
        _damaged.Damaged -= OnDamaged;
    }

    protected abstract void OnDamaged();
}