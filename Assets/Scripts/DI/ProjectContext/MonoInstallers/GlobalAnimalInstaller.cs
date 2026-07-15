using Zenject;

public class GlobalAnimalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            BindInterfacesAndSelfTo<AnimalData>().
            AsSingle();
    }
}