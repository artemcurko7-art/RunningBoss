using Game.Scripts.Inventory.ItemContext;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalItemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ItemData>()
                .AsSingle();
        }
    }
}