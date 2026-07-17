using Game.Scripts.Factories;
using Game.Scripts.MV.DistanceMap.Model;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class DistanceMapInstaller : MonoInstaller
    {
        [SerializeField] private Transform _currentPoint;
        [SerializeField] private GameObject _finishedPoint;
        [SerializeField] private float _offsetFinished;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<DistanceMap>()
                .AsSingle();

            Container
                .Bind<CalculationDistanceMap>()
                .AsSingle()
                .WithArguments(_currentPoint);

            Container
                .Bind<DistanceMapPointFactory>()
                .AsSingle()
                .WithArguments(_finishedPoint, _offsetFinished);
        }
    }
}