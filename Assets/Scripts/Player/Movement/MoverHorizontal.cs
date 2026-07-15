using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MoverHorizontal : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerBody;
    [SerializeField] private AnimationCurve _accelerationCurve;
    [SerializeField] private AnimationCurve _brakingCurve;
    [SerializeField] private float _accelerationTime = 0.5f;
    [SerializeField] private float _brakingTime = 0.3f;
    [SerializeField] private float _stopThreshold = 0.05f; 

    private const float RangePosition = 3.6f;
    private Animal _animal;
    
    private float _currentSpeed;
    private float _currentDirection;
    private float _targetDirection;
    private float _directionTransitionTime;
    private bool _isBraking;
    
    private void FixedUpdate()
    {
        if (GamePaused.Type == GamePausedType.Pause)
            return;
        
        float tDirection;
        
        if (_isBraking)
        {
            _directionTransitionTime += Time.fixedDeltaTime;
            tDirection = Mathf.Clamp01(_directionTransitionTime / _brakingTime);
            
            float brakeFactor = 1f - _brakingCurve.Evaluate(tDirection);
            _currentDirection = Mathf.Lerp(_currentDirection, 0f, brakeFactor);

            _currentSpeed = Mathf.Lerp(_currentSpeed, 0f, 0.15f);

            if (Mathf.Abs(_currentDirection) < _stopThreshold && Mathf.Abs(_currentSpeed) < 0.1)
            {
                _isBraking = false;

                _playerBody.velocity = Vector3.zero;
                _playerBody.angularVelocity = Vector3.zero;
            }
        }
        else if (Mathf.Abs(_currentDirection - _targetDirection) > _stopThreshold)
        {
            _directionTransitionTime += Time.fixedDeltaTime;
            tDirection = Mathf.Clamp01(_directionTransitionTime / _accelerationTime);

            if (Mathf.Approximately(_playerBody.position.x, -RangePosition) || Mathf.Approximately(_playerBody.position.x, RangePosition))
                _currentDirection = Mathf.Lerp(_currentDirection, _targetDirection, 0.5f);
            else
                _currentDirection = Mathf.Lerp(_currentDirection, _targetDirection, _accelerationCurve.Evaluate(tDirection));
        }
        
        float targetSpeed = _animal.Stats[StatType.Dexterity].Value / 5f;
        _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, 0.1f);
            
        Vector3 newPosition = _playerBody.position;
        newPosition.x += _currentSpeed * _currentDirection * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -RangePosition, RangePosition);
        
        _playerBody.position = newPosition;
    }
    
    public void MoveRight()
    {
        _targetDirection = 1f;
        _isBraking = false;
        _directionTransitionTime = 0f;
    }
    
    public void MoveLeft()
    {
        _targetDirection = -1f;
        _isBraking = false;
        _directionTransitionTime = 0f;
    }
    
    public void ReduceSpeed()
    {
        _isBraking = true;
        _directionTransitionTime = 0f;
    }
    
    public void Stop()
    {
        _targetDirection = 0f;
        _isBraking = true;
        _directionTransitionTime = 0f;
    }
    
    [Inject]
    public void Construct(Animal animal)
    {
        _animal = animal;
    }
}