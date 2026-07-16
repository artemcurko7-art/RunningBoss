public abstract class KilledSubscriber : ISubscriber
{
    private readonly IKilled _killed;
    
    public KilledSubscriber(IKilled killed)
    {
        _killed = killed;     
    }

    public void Subscribe()
    {
        _killed.Killed += OnKilled;
    }

    public void Unsubscribe()
    {
        _killed.Killed -= OnKilled;
    }

    protected abstract void OnKilled();
}