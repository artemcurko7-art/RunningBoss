public class PlaybackSoundFinished : FinishedSubscriber
{
    private readonly SoundService _service;

    private PlaybackSoundFinished(IFinished finished, SoundService service) 
        : base(finished)
    {
        _service = service;
    }

    protected override void OnFinished()
    {
        _service.Sounds[SoundType.Finished].Play();
    }
}