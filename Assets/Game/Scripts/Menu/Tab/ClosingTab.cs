using UnityEngine;
using Zenject;

public class ClosingTab : Tab
{
    private Transform _currentHierarchy;

    [Inject]
    public void Construct()
    {
        _currentHierarchy = View.transform.parent;
    }

    protected override void OnClick()
    {
        if (Service != null)
            Service.Enable();

        View.gameObject.SetActive(false);
        View.transform.SetParent(_currentHierarchy);
        
        AudioSource.Play();
    }
}