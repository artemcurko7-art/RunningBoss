using UnityEngine;
using Zenject;

public class PlayerDeathInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.
            Bind<ISubscriber>().
            To<ProgressDeath>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<PlaybackSoundDeath>().
            AsCached();
        
        Container.
            Bind<ISubscriber>().
            To<EffectorDeath>().
            AsCached();
    }
}