public abstract class DeathSubscriber : ISubscriber
{
    private readonly IDeath _death;
    
    public DeathSubscriber(IDeath death)
    {
        _death = death;
    }

    public void Subscribe()
    {
        _death.Died += OnDied;
    }

    public void Unsubscribe()
    {
        _death.Died -= OnDied;
    }

    protected abstract void OnDied();
}