using Game.Scripts.Animal.Data;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalAnimalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<AnimalData>()
                .AsSingle();
        }
    }
}