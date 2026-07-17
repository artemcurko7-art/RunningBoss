using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.Animal.Review
{
    public class RotationReviewHorizontal : MonoBehaviour, IPointerMoveHandler
    {
        private const int MaxAngle = 180;

        [SerializeField] private Transform _model;
        [SerializeField] private float _sensivity;
        [SerializeField] private float _smooth;

        private bool _isDragging;
        private float _targetRotationY;

        private void Update()
        {
            if (_isDragging)
            {
                Quaternion targetRotation = Quaternion.Euler(0, -_targetRotationY, 0);
                _model.rotation = Quaternion.Lerp(_model.rotation, targetRotation, _smooth * Time.deltaTime);
            }
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (_isDragging)
            {
                float normalizedX = eventData.position.x / Screen.width;
                _targetRotationY = Mathf.Lerp(-MaxAngle, MaxAngle, normalizedX);
            }
        }

        public void EnableIsDragging()
        {
            _isDragging = true;
        }

        public void DisableIsDragging()
        {
            _isDragging = false;
        }
    }
}