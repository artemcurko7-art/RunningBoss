using Game.Scripts.Animal.Type;
using Game.Scripts.MV.Stat.Health;
using Game.Scripts.MVC.Stat.Type;
using Game.Scripts.Player;
using Game.Scripts.Player.Coin;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private CoinStats _stats;

        private Animal.Animal _animal;

        [Inject]
        public void Construct(Animal.Animal animal)
        {
            _animal = animal;
        }

        public override void InstallBindings()
        {
            BindHealth();
            BindCollectorCoin();
        }

        private void BindHealth()
        {
            Container
                .BindInterfacesAndSelfTo<Health>()
                .FromInstance(new Health(AnimalType.None, null, _animal.Stats[StatType.Health].Value))
                .AsSingle();
        }

        private void BindCollectorCoin()
        {
            Container
                .BindInterfacesAndSelfTo<CoinData>()
                .AsSingle();

            Container
                .Bind<CoinStats>()
                .FromInstance(_stats)
                .AsSingle();
        }
    }
}