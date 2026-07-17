using Game.Scripts.MV.Quest;
using Game.Scripts.MV.Quest.QuestData;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.ProjectContext.MonoInstallers
{
    public class GlobalQuestInstaller : MonoInstaller
    {
        [SerializeField] private QuestView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<QuestData>()
                .To<EasyQuestData>()
                .AsCached()
                .NonLazy();

            Container
                .Bind<QuestData>()
                .To<MiddleQuestData>()
                .AsCached()
                .NonLazy();

            Container
                .Bind<QuestData>()
                .To<HardQuestData>()
                .AsCached()
                .NonLazy();

            Container
                .Bind<QuestView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}