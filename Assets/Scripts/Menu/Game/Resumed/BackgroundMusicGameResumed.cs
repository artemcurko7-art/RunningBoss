public class BackgroundMusicGameResumed : GameResumedSubscriber
{
    private readonly BackgroundMusicService _service;
    
    public BackgroundMusicGameResumed(IGame game, BackgroundMusicService service) 
        : base(game)
    {
        _service = service;
    }

    protected override void OnGameResumed()
    {
        foreach (var music in _service.BackgroundMusics.Values)
            music.Stop();
        
        _service.BackgroundMusics[BackgroundMusicType.Gameplay].Play();
    }
}