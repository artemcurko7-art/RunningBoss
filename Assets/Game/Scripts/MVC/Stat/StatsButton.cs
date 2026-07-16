using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StatsButton : MonoBehaviour
{
    [SerializeField] private StatType _type;
    [SerializeField] private Button _button; 
    
    private AnimalView _animalView;
    private StatsController _controller;
    private IAnimalSelected _selected;
    private SoundService _soundService;
    
    [Inject]
    public void Construct(StatsController controller, IAnimalSelected selected, SoundService soundService)
    {
        _controller = controller;
        _selected = selected;
        _soundService = soundService;
        
        _selected.Selected += OnSelected;
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnDestroy()
    {
        _selected.Selected -= OnSelected;
        _button.onClick.RemoveListener(OnClick);
    }
    
    private void OnSelected(AnimalView animalView)
    {
        _animalView = animalView;
    }

    private void OnClick()
    {
        _controller.ProcessHandler(_type, _animalView);
        _soundService.Sounds[SoundType.StatLevelUp].Play();
    }
}