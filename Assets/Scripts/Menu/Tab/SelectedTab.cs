using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedTab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _size;
    [SerializeField] private float _duration;

    private Vector3 _currentScale;
    
    private void Start()
    {
        _currentScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_currentScale * _size, _duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_currentScale, _duration);
    }
}