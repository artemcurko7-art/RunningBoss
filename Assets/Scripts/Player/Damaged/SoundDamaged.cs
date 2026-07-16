public class SoundDamaged : DamagedSubscriber
{
    private readonly SoundService _service;
    
    public SoundDamaged(IDamaged damaged, SoundService service)
        : base(damaged)
    {
        _service = service;
    }

    protected override void OnDamaged()
    {
        _service.Sounds[SoundType.Obstacle].Play();
    }
}