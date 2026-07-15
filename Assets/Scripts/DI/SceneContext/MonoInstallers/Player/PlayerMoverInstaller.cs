using UnityEngine;
using Zenject;

public class PlayerMoverInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<MoverForward>().
            AsSingle();
    }
}