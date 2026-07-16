using UnityEngine;

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