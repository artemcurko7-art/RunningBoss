using Zenject;

public class GlobalItemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<ItemData>().
            AsSingle();
    }
}