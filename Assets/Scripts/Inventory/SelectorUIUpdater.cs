using UnityEngine;
using UnityEngine.UI;

public class SelectorUIUpdater 
{
    public void Update(InventoryService inventoryService, Button button, Image selected)
    {
        foreach (var cell in inventoryService.Cells)
        {
            if (Mathf.Approximately(cell.FillAmount, 1))
            {
                cell.Selector.Button.interactable = true;
                cell.Selector.Selected.gameObject.SetActive(false);
            }
        }
        
        button.interactable = false;
        selected.gameObject.SetActive(true);
    }

    public void Update(AnimalView animalView, InventoryService inventoryService)
    {
        foreach (var cell in inventoryService.Cells)
        {
            cell.Selector.Button.interactable = Mathf.Approximately(cell.FillAmount, 1);
            cell.Selector.Selected.gameObject.SetActive(false);
            
            if (animalView.Animal.ItemView == null)
                return;
            
            if (cell.Type == animalView.Animal.ItemView.Type)
            {
                cell.Selector.OnClick();      
                cell.Selector.Button.interactable = false;
                cell.Selector.Selected.gameObject.SetActive(true);
            }
        }
    }
}