using UnityEngine;

public class FollowerToTargets : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        foreach (var target in _targets)
        {
            transform.position = new Vector3(transform.position.x, target.position.y + _offset.y, target.position.z + _offset.z);
        }
    }
}