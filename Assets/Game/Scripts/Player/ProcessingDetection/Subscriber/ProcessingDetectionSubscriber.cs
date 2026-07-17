using Game.Scripts.PoolMono.ObjectPool.Unit;
using Game.Scripts.Service;

namespace Game.Scripts.Player.ProcessingDetection.Subscriber
{
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
}