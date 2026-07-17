using UnityEngine;

namespace Game.Scripts.Service
{
    public class TabService
    {
        private readonly GameObject[] _disablings;

        public TabService(GameObject[] disablings)
        {
            _disablings = disablings;
        }

        public void Enable()
        {
            foreach (var disabling in _disablings)
                disabling.SetActive(true);
        }

        public void Disable()
        {
            foreach (var disabling in _disablings)
                disabling.SetActive(false);
        }
    }
}