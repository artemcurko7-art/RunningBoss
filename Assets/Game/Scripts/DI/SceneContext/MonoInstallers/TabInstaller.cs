using Game.Scripts.Service;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class TabInstaller : MonoInstaller
    {
        [SerializeField] private GameObject[] _disablings;

        public override void InstallBindings()
        {
            Container
                .Bind<TabService>()
                .AsSingle()
                .WithArguments(_disablings);
        }
    }
}