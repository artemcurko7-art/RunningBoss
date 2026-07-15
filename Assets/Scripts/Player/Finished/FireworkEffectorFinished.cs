using UnityEngine;

public class FireworkEffectorFinished : FinishedSubscriber
{
    private readonly EffectorData _data;
    private readonly Transform _transform;
    
    public FireworkEffectorFinished(IFinished finished, EffectorData data, Transform transform) : base(finished)
    {
        _data = data;
        _transform = transform;
    }

    protected override void OnFinished()
    {
        for (int i = 0; i < _transform.childCount; i++)
            GameObject.Instantiate(_data.Effectors[EffectorType.RunFirework], _transform.GetChild(i).position, Quaternion.identity);
    }
}