public class PlaybackSoundKilled : KilledSubscriber
{
    private readonly SoundService _service;

    private PlaybackSoundKilled(IKilled killed, SoundService service) : base(killed)
    {
        _service = service;
    }

    protected override void OnKilled()
    {
        _service.Sounds[SoundType.Killed].Play();
    }
}