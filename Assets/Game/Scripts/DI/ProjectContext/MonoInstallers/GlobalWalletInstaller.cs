using Game.Scripts.MV.Wallet;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalWalletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Wallet>()
                .AsSingle();
        }
    }
}