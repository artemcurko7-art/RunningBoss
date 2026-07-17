using Game.Scripts.MV.Level.GameLevel.Experience.Model;
using Game.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalExperienceInstaller : MonoInstaller
    {
        [SerializeField] private ExperienceStats _stats;
    
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameExperience>()
                .AsSingle();
        
            Container
                .Bind<ExperienceStats>()
                .FromInstance(_stats)
                .AsSingle();
        }
    }
}