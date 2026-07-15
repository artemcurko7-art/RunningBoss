using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class SelectorEmptyItemButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _selected;
    
    private IAnimalData _animalData;
    private InventoryService _inventoryService;
    private IAnimalSelected _animalSelected;
    private AnimalView _animalView;
    private SoundService _soundService;
    
    [Inject]
    public void Construct(IAnimalData animalData, InventoryService inventoryService, IAnimalSelected animalSelected, SoundService soundService)
    {
        _animalData = animalData;
        _inventoryService = inventoryService;
        _animalSelected = animalSelected;
        _soundService = soundService;

        _animalSelected.Selected += OnAnimalSelected;
        _button.onClick.AddListener(OnClick);

        foreach (var cell in _inventoryService.Cells)
            cell.Selector.Clicked += OnClicked;
    }

    private void OnDestroy()
    {
        _animalSelected.Selected -= OnAnimalSelected;
        _button.onClick.RemoveListener(OnClick);
        
        foreach (var cell in _inventoryService.Cells)
            cell.Selector.Clicked -= OnClicked;
    }

    private void OnClick()
    {
        _animalData.Views[_animalView.Animal.Type].Animal.SetItem(null);
        _button.interactable = false;
        _selected.gameObject.SetActive(true);
        
        foreach (var type in YG2.saves.TotalAmountAnimals)
            if (_animalView.Animal.Type == type)
                YG2.saves.OwnedByItems[type] = ItemType.None;
        
        foreach (var cell in _inventoryService.Cells)
        {
            if (Mathf.Approximately(cell.FillAmount, 1))
            {
                cell.Selector.Button.interactable = true;
                cell.Selector.Selected.gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < _animalView.ItemContainer.childCount; i++)
            _animalView.ItemContainer.GetChild(i).gameObject.SetActive(false);
        
        _soundService.Sounds[SoundType.Tab].Play();
    }

    private void OnClicked(ItemType type, Button button, Image selected)
    {
        if (_animalView == null)
            return;

        if (_selected == null)
            return;

        _button.interactable = selected.gameObject.activeSelf == false;
        _selected.gameObject.SetActive(selected.gameObject.activeSelf);
    }
    
    private void OnAnimalSelected(AnimalView animalView)
    {
        if (_selected == null)
            return;
        
        _animalView = animalView;
        
        _button.interactable = _animalView.Animal.ItemView != null;
        _selected.gameObject.SetActive(_animalView.Animal.ItemView == null);
    }
}