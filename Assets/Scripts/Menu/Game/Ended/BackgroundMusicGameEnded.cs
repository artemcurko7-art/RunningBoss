public class BackgroundMusicGameEnded : GameEndedSubscriber
{
    private readonly BackgroundMusicService _service;
    
    public BackgroundMusicGameEnded(IGame game, BackgroundMusicService service) : base(game)
    {
        _service = service;
    }
    
    protected override void OnGameEnded()
    {
        foreach (var music in _service.BackgroundMusics.Values)
            music.Stop();
        
        _service.BackgroundMusics[BackgroundMusicType.GameEnded].Play();
    }
}