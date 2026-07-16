public class FinishedGameEnded : ISubscriber
{
    private readonly Game _game;
    private readonly IFinished _finished;
    
    public FinishedGameEnded(Game game, IFinished finished)
    {
        _game = game;
        _finished = finished;
    }

    public void Subscribe()
    {
        _finished.Finished += _game.OnEnded;
    }

    public void Unsubscribe()
    {
        _finished.Finished -= _game.OnEnded;
    }
}