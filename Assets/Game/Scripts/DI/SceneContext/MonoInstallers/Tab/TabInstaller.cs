using UnityEngine;
using Zenject;

public class TabInstaller : MonoInstaller
{
    [SerializeField] private GameObject[] _disablings;

    public override void InstallBindings()
    {
        Container
            .Bind<TabService>()
            .AsSingle()
            .WithArguments(_disablings);
    }
}