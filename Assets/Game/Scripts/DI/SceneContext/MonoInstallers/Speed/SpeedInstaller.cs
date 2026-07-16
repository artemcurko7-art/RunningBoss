using UnityEngine;
using Zenject;

public class SpeedInstaller : MonoInstaller
{
    [SerializeField] private SpeedStats _stats;
    
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<Speed>()
            .AsSingle()
            .WithArguments(_stats);
    }
}