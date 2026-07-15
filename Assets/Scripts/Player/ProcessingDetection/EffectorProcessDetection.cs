public class EffectorProcessDetection : ProcessingDetectionSubscriber
{
    private readonly EffectorData _data;
    private readonly EffectorPool _pool;
    
    public EffectorProcessDetection(IProcessingDetected detected, EffectorData data, EffectorPool pool) : base(detected)
    {
        _data = data;
        _pool = pool;
    }

    protected override void OnDetected(Unit unit)
    {
        _pool.Spawn(_data.Effectors[EffectorType.BloodBurst], unit.Death.Hips);
    }
}