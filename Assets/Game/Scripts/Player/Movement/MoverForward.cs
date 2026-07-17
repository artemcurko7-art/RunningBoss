using UnityEngine;

namespace Game.Scripts.Player.Movement
{
    public class MoverForward
    {
        public void Move(Rigidbody rigidbody, Vector3 direction, float speed)
        {
            rigidbody.position += direction * (speed * Time.deltaTime);
        }
    }
}