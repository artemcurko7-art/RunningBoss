using Zenject;

public class GlobalLevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindGame();
        BindLocation();
    }

    private void BindGame()
    {
        Container.
            BindInterfacesTo<GameLevel>().
            AsSingle();
    }
    
    private void BindLocation()
    {
        Container.
            BindInterfacesAndSelfTo<LocationLevel>(). 
            AsSingle();
    }
}