using UnityEngine;
using Zenject;

public abstract class DistanceMapView : MonoBehaviour
{
    protected IDistanceMap Model { get; private set; }
    
    [Inject]
    public void Construct(IDistanceMap model)
    {
        Model = model;
        
        Model.Changed += OnValueChanged;
    }

    private void OnDestroy()
    {
        Model.Changed -= OnValueChanged;
    }

    protected abstract void OnValueChanged(float value);
}