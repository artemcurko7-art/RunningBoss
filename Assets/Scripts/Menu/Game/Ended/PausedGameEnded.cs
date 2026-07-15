public class PausedGameEnded : ISubscriber
{
    private readonly Game _game;
    
    public PausedGameEnded(Game game)
    {
        _game = game;
    }
    
    public void Subscribe()
    {
        _game.Ended += _game.OnPaused;
    }

    public void Unsubscribe()
    {
        _game.Ended -= _game.OnPaused;
    }
}