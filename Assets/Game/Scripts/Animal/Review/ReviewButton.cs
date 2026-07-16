using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReviewButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RotationReviewHorizontal _rotation;
    [SerializeField] private Button _button;
    [SerializeField] private Image _zone;
    [SerializeField] private Image _zoneClicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        _button.interactable = false;   
        _rotation.EnableIsDragging();
        _zone.enabled = true;
        _zoneClicked.enabled = false;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _button.interactable = true;
        _rotation.DisableIsDragging();
        _zone.enabled = false;
        _zoneClicked.enabled = true;
    }
}