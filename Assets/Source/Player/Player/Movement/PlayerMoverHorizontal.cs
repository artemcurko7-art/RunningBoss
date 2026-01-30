using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoverHorizontal : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
{
    private const float RangePosition = 1.8f;
    private MoverHorizontal _mover;
    private Transform _target;
    private float _movementHorizontalSpeed;
    private bool _isClicked;
    
    public void Initialize(MoverHorizontal mover, Transform target, float movementHorizontalSpeed)
    {
        _mover = mover; 
        _target = target;
        _movementHorizontalSpeed = movementHorizontalSpeed;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _isClicked = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isClicked = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isClicked = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (_isClicked)
            _mover.Move(_target, eventData.delta, _movementHorizontalSpeed, RangePosition);
    }
}