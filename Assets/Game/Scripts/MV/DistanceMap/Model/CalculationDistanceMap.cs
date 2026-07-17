using Game.Scripts.Factories;
using UnityEngine;

namespace Game.Scripts.MV.DistanceMap.Model
{
    public class CalculationDistanceMap
    {
        private readonly Transform _currentPoint;
        private readonly GameObject _point;

        public CalculationDistanceMap(DistanceMapPointFactory factory, Transform currentPoint)
        {
            _currentPoint = currentPoint;

            _point = factory.Create();
        }

        public float GetDistance() =>
            _point.transform.position.z - _currentPoint.transform.position.z;
    }
}