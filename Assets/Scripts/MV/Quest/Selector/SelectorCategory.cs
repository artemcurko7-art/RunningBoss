using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SelectorCategory : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _category;
    [SerializeField] private GameObject[] _categories;
    [SerializeField] private Image[] _images;

    private SoundService _soundService;
    private bool _isDataActive;

    [Inject]
    public void Construct(SoundService soundService)
    {
        _soundService = soundService;
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        foreach (var category in _categories)
            category.SetActive(false);
        
        foreach (var image in _images)
            image.color = new Color(255, 255, 255, 255);
        
        _category.SetActive(true);
        _image.color = new Color(255, 0, 255, 255);
        
        _soundService.Sounds[SoundType.Tab].Play();
    }
}