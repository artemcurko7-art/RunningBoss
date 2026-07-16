using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class VisibleSelectorButton : MonoBehaviour
{
    [field: SerializeField] protected Button Button { get; private set; }
    
    protected IAnimalSelectedButton Selected { get; private set; }
    
    [Inject]
    public virtual void Construct(IAnimalSelectedButton selected)
    {
        Selected = selected;
    }
    
    protected void OnSelected(bool isValue)
    {
        Button.interactable = isValue == false;
    }
    
    protected abstract void OnDestroy();
}