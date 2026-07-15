public class BackgroundMusicGamePaused : GamePausedSubscriber
{
    private readonly BackgroundMusicService _service;
    
    public BackgroundMusicGamePaused(IGame game, BackgroundMusicService service) : base(game)
    {
        _service = service;
    }

    protected override void OnGamePaused()
    {
        foreach(var music in _service.BackgroundMusics.Values)
            music.Stop();
        
        _service.BackgroundMusics[BackgroundMusicType.Waiting].Play();
    }
}