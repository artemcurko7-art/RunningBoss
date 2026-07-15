using Zenject;

public class GlobalWalletInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            BindInterfacesAndSelfTo<Wallet>().
            AsSingle();
    }
}