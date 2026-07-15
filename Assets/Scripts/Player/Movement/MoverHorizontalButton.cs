using UnityEngine;
using UnityEngine.EventSystems;

public class MoverHorizontalButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private MoverHorizontal _mover;
    [SerializeField] private GameResumedClicked _gameResumed;
    [SerializeField] private bool _isLeft; 

    private static bool _isLeftPressed;
    private static bool _isRightPressed;
    private static bool _isLeftQueued;   
    private static bool _isRightQueued;
    private bool _isResumed;
    
    private static MoverHorizontalButton _leftButton;
    private static MoverHorizontalButton _rightButton;
    
    private void Awake()
    {
        if (_isLeft)
            _leftButton = this;
        else
            _rightButton = this;
    }

    private void Update()
    {
        if (_isLeftPressed == false && _isRightPressed == false)
            _mover.ReduceSpeed();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isLeft)
            HandleLeftDown();
        else
            HandleRightDown();

        if (_isResumed == false)
        {
            _gameResumed.OnGameResumed();
            _leftButton.EnableResumed();
            _rightButton.EnableResumed();
        }
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isLeft)
            HandleLeftUp();
        else
            HandleRightUp();
    }
    
    private void HandleLeftDown()
    {
        if (_isRightPressed)
            _isLeftQueued = true; 
        else
            ActivateLeft();
    }
    
    private void HandleRightDown()
    {
        if (_isLeftPressed)
            _isRightQueued = true;
        else
            ActivateRight();
    }
    
    private void HandleLeftUp()
    {
        _isLeftPressed = false;
        _isLeftQueued = false;
        
        if (_isRightQueued)
            ActivateRight();
    }
    
    private void HandleRightUp()
    {
        _isRightPressed = false;
        _isRightQueued = false;
        
        if (_isLeftQueued)
            ActivateLeft();
    }
    
    private void ActivateLeft()
    {
        _isLeftPressed = true;
        _isRightPressed = false;
        _isLeftQueued = false;
        _isRightQueued = false;
        _mover.MoveLeft();
    }
    
    private void ActivateRight()
    {
        _isRightPressed = true;
        _isLeftPressed = false;
        _isLeftQueued = false;
        _isRightQueued = false;
        _mover.MoveRight();
    }

    public void EnableResumed()
    {
        _isResumed = true;
    }
}