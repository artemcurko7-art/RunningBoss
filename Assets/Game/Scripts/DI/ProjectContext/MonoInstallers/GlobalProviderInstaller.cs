using Game.Scripts.Provider;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalProviderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<AnimalProvider>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ItemViewProvider>()
                .AsSingle();

            Container
                .Bind<InterstitialAdsProvider>()
                .AsSingle();

            Container
                .Bind<LanguageProvider>()
                .AsSingle();
        }
    }
}