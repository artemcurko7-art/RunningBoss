using UnityEngine;

namespace Game.Scripts.Player
{
    public class FollowToTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, _target.position.y + _offset.y,
                _target.position.z + _offset.z);
        }
    }
}