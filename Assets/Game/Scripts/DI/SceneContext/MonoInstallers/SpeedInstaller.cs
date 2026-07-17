using Game.Scripts.MV.Speed;
using Game.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class SpeedInstaller : MonoInstaller
    {
        [SerializeField] private SpeedStats _stats;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Speed>()
                .AsSingle()
                .WithArguments(_stats);
        }
    }
}