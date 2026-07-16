using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class Tab : MonoBehaviour
{
    [SerializeField] private Button _button;

    [field: SerializeField] protected TabView View { get; private set; }
    
    protected TabService Service { get; private set; }
    protected AudioSource AudioSource { get; private set; }
    
    [Inject]
    public void Consturct([InjectOptional] TabService service, SoundService soundService)
    {
        Service = service;

        AudioSource = soundService.Sounds[SoundType.Tab];
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    protected abstract void OnClick();
}