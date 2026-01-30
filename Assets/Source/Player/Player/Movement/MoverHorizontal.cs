using UnityEngine;

public class MoverHorizontal 
{
    public void Move(Transform transform, Vector3 direction, float speed, float rangePosition)
    {
        var position = Vector3.right * new Vector2(direction.x, direction.z).normalized * speed * Time.deltaTime;
        transform.Translate(position);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -rangePosition, rangePosition), transform.position.y, transform.position.z);
    }
}
