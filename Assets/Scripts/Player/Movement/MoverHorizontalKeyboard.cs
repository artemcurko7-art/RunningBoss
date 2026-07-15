using UnityEngine;

public class MoverHorizontalKeyboard : MonoBehaviour
{
    [SerializeField] private MoverHorizontal _mover;
    
    private bool _isLeftPressed;
    private bool _isRightPressed;
    private bool _isReduceSpeed;
    
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A)) && _isRightPressed == false)
        {
            _mover.MoveLeft();
            _isLeftPressed = true;
            _isReduceSpeed = false;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            _isLeftPressed = false;
            _isReduceSpeed = true;
        }
        
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D)) && _isLeftPressed == false)
        {
            _mover.MoveRight();
            _isRightPressed = true;
            _isReduceSpeed = false;
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            _isRightPressed = false;
            _isReduceSpeed = true;
        }

        if (_isReduceSpeed)
            _mover.ReduceSpeed();
    }
}
