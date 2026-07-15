using UnityEngine;

public class OpeningTab : Tab
{
    [SerializeField] private RectTransform _menu;
    
    private bool _isDataActive;
    
    protected override void OnClick()
    {
        if (Service != null)
            Service.Disable();
        
        View.gameObject.SetActive(true);
        View.transform.SetParent(_menu);
        View.transform.SetSiblingIndex(_menu.childCount - 1);
        
        AudioSource.Play();
    }
}