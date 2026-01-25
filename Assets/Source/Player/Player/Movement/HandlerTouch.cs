using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandlerTouch : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _rangePosition;

    private TargetMover _mover;

    public bool _isClicked { get; private set; }

    private void Awake()
    {
        _mover = new TargetMover(_target, _speed, _rangePosition);
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
            _mover.Move(eventData.delta);
    }
}