using UnityEngine;
using Zenject;

public class GlobalExperienceInstaller : MonoInstaller
{
    [SerializeField] private ExperienceStats _stats;
    
    public override void InstallBindings()
    {
        Container.
            BindInterfacesAndSelfTo<GameExperience>().
            AsSingle();
        
        Container.
            Bind<ExperienceStats>().
            FromInstance(_stats).
            AsSingle();
    }
}