using UnityEngine;
using UnityEngine.UI;

public abstract class VolumeChanged : MonoBehaviour
{
    [field: SerializeField] protected Slider Slider { get; private set; }

    private void OnEnable()
    {
        Slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        Slider.onValueChanged.RemoveListener(OnValueChanged);
    }

    protected abstract void OnValueChanged(float value);
}