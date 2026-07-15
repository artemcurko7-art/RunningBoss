public class PlaybackSoundDeath : DeathSubscriber
{
    private readonly SoundService _service;

    public PlaybackSoundDeath(IDeath death, SoundService service) : base(death)
    {
        _service = service;
    }

    protected override void OnDied()
    {
        _service.Sounds[SoundType.Death].Play();
    }
}