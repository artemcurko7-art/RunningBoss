public class EffectorDeath : DeathSubscriber
{
    private readonly EffectorData _data;
    private readonly EffectorPool _pool;
    private readonly AnimalView _animalView;
    
    public EffectorDeath(IDeath death, EffectorData data, EffectorPool pool, AnimalView animalView) 
        : base(death)
    {
        _data = data;
        _pool = pool;
        _animalView = animalView;
    }

    protected override void OnDied()
    {
        _pool.Spawn(_data.Effectors[EffectorType.Death], _animalView.transform);
    }
}