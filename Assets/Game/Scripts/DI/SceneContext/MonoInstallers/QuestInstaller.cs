using Game.Scripts.Factories;
using Game.Scripts.Service;
using UnityEngine;
using YG;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class QuestInstaller : MonoInstaller
    {
        [SerializeField] private RectTransform[] _mobileContainers;
        [SerializeField] private RectTransform[] _desktopContainers;

        private RectTransform[] _currentContainers;

        public override void InstallBindings()
        {
            _currentContainers = YG2.envir.isMobile ? _mobileContainers : _desktopContainers;

            Container
                .Bind<QuestService>()
                .AsSingle()
                .WithArguments(_currentContainers)
                .NonLazy();

            Container
                .Bind<QuestViewFactory>()
                .AsSingle();
        }
    }
}