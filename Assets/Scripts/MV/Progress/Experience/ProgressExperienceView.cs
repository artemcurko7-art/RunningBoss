using UnityEngine;

public abstract class ProgressExperienceView : MonoBehaviour
{
    protected ProgressExperience Experience { get; private set; }
    
    public virtual void Initialize(ProgressExperience experience)
    {
        Experience = experience;

        Experience.Changed += OnValueChanged;
    }

    private void OnDestroy()
    {
        Experience.Changed -= OnValueChanged;
    }

    protected abstract void OnValueChanged(int value);
}