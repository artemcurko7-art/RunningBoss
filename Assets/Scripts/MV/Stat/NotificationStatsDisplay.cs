using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NotificationStatsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelDisplays;
    [SerializeField] private GameObject[] _maxLevelIcons;

    private IReadOnlyList<AnimalView> _animalViews;
    private AnimalView _animalView;
    private ISkillPoint _skillPoint;
    private IAnimalSelected _selected;
    private int _index;
    
    [Inject]
    public void Construct(ISkillPoint skillPoint, IAnimalSelected selected)
    {
        _skillPoint = skillPoint;
        _selected = selected;
        
        _skillPoint.Changed += OnValueChanged;
        _selected.Selected += OnSelected;
        _selected.Update();
    }

    public void Initialize(IReadOnlyList<AnimalView> animalViews)
    {
        _animalViews = animalViews;
    }

    private void OnDestroy()
    {
        _skillPoint.Changed -= OnValueChanged;
        _selected.Selected -= OnSelected;
    }

    private void OnSelected(AnimalView view)
    {
        _animalView = view;
        
        _skillPoint.Update();
        
        foreach (var levelIcon in _maxLevelIcons)
            levelIcon.SetActive(false);
        
        foreach (var stat in view.Animal.Stats.Values)
        {
            _index++;
            
            ChangeStatView(stat);
        }
        
        _index = 0;
    }
    
    private void OnValueChanged(int value)
    {
        if (_animalView == null)
            return;
        
        foreach (var display in _levelDisplays)
            display.SetActive(value > 0);
        
        foreach (var stat in _animalView.Animal.Stats.Values)
        {
            _index++;
            
            ChangeStatView(stat);
        }

        _index = 0;
    }

    private void ChangeStatView(Stat stat)
    {
        if (stat.ImprovementConfig.Values.Length == stat.Level)
        {
            _maxLevelIcons[_index - 1].SetActive(true);
            _levelDisplays[_index - 1].gameObject.SetActive(false);
        }
    }
}