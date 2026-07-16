public abstract class FinishedSubscriber : ISubscriber
{
    private readonly IFinished _finished;
    
    public FinishedSubscriber(IFinished finished)
    {
        _finished = finished;
    }

    public void Subscribe()
    {
        _finished.Finished += OnFinished;
    }

    public void Unsubscribe()
    {
        _finished.Finished -= OnFinished;
    }

    protected abstract void OnFinished();
}