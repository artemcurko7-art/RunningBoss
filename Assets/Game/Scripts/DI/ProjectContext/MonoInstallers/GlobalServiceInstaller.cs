using Game.Scripts.Service.Inventory.ItemContext;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ItemViewService>()
                .AsSingle();
        }
    }
}