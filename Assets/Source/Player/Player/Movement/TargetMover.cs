using UnityEngine;

public class TargetMover : Mover
{
    private readonly float _rangePosition;

    public TargetMover(Transform transform, float speed, float rangePosition) : base(transform, speed) 
    {
        _rangePosition = rangePosition;
    }

    public override void Move(Vector3 direction)
    {
        var position = Vector3.right * new Vector2(direction.x, direction.z).normalized * Speed * Time.deltaTime;
        Transform.Translate(position);
        Transform.position = new Vector3(Mathf.Clamp(Transform.position.x, -_rangePosition, _rangePosition), Transform.position.y, Transform.position.z);
    }
}
