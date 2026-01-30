using UnityEngine;
 
public class MoverForward 
{
    public void Move(Transform transform, Vector3 direction, float speed)
    {
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}