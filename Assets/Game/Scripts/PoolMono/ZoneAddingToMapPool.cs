using Game.Scripts.PoolMono.ObjectPool.Map;
using UnityEngine;

namespace Game.Scripts.PoolMono
{
    public class ZoneAddingToMapPool : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out Map map))
            {
                map.OnDisabled();
            }
        }
    }
}