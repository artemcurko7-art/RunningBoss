using UnityEngine;
using Zenject;

public abstract class GameExperienceView : MonoBehaviour
{
    private IGameExperience _model;
    
    [Inject]
    public void Construct(IGameExperience model)
    {
        _model = model;
    }

    private void OnEnable()
    {
        _model.ValueChanged += OnValueChanged;
        _model.Update();
    }

    private void OnDisable()
    {
        _model.ValueChanged -= OnValueChanged;
    }

    protected abstract void OnValueChanged(int value, int maxValue);
}