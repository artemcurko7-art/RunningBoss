using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowerToTargets : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        for (int i = 0; i < _targets.Length; i++)
        {
            transform.position = _targets[i].position + _offset;
        }
    }
}