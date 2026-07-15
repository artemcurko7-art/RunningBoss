public class GameplayGamePaused : GamePausedSubscriber
{
    private readonly IGame _game;
    
    public GameplayGamePaused(IGame game) : base(game) {}

    protected override void OnGamePaused()
    {
        GamePaused.Set(GamePausedType.Pause);
    }
}