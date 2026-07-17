using Game.Scripts.Factories;
using Game.Scripts.Service;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class GeneralAnimallInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<AnimalService>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<AnimalViewFactory>()
                .AsSingle();
        }
    }
}