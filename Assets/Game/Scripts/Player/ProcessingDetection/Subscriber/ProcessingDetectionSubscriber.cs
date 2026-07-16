public abstract class ProcessingDetectionSubscriber : ISubscriber
{
    private readonly IProcessingDetected _detected;
    
    public ProcessingDetectionSubscriber(IProcessingDetected detected)
    {
        _detected = detected;
    }
    
    public void Subscribe()
    {
        _detected.Detected += OnDetected;
    }

    public void Unsubscribe()
    {
        _detected.Detected -= OnDetected;
    }

    protected abstract void OnDetected(Unit unit);
}