public class GameplayGameResumed : GameResumedSubscriber
{
    private readonly IGame _game;

    public GameplayGameResumed(IGame game) : base(game) { }

    protected override void OnGameResumed()
    {
        GamePaused.Set(GamePausedType.Play);
    }
}