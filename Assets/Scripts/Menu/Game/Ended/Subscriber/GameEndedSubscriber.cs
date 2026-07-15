public abstract class GameEndedSubscriber : ISubscriber
{
    private readonly IGame _game;
    
    public GameEndedSubscriber(IGame game)
    {
        _game = game;
    }
    
    public virtual void Subscribe()
    {
        _game.Ended += OnGameEnded;
    }

    public virtual void Unsubscribe()
    {
        _game.Ended -= OnGameEnded;
    }

    protected abstract void OnGameEnded();
}