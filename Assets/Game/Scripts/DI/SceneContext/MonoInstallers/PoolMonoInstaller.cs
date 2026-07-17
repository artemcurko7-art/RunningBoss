using Game.Scripts.GameWorld;
using Game.Scripts.PoolMono.ObjectPool.Map;
using Game.Scripts.PoolMono.ObjectPool.Obstacle;
using Game.Scripts.PoolMono.ObjectPool.Unit;
using Game.Scripts.PoolMono.Pool;
using Game.Scripts.PoolMono.SettingPosition;
using Game.Scripts.Service.PhysicalBody.Map;
using Game.Scripts.Service.PhysicalBody.Obstacle;
using Game.Scripts.Service.PhysicalBody.Unit;
using UnityEngine;
using Zenject;

namespace Game.Scripts.DI.SceneContext.MonoInstallers
{
    public class PoolMonoInstaller : MonoInstaller
    {
        [Header("Unit")] [SerializeField] private Transform _player;
        [SerializeField] private float _delaySpawn;

        [Header("Map")] [SerializeField] private int _maxSpawned;

        private Unit[] _units;
        private Map[] _maps;
        private Obstacle[] _obstacles;

        [Inject]
        public void Construct(GameWorldProvider gameWorld)
        {
            _units = gameWorld.Config.Units;
            _maps = gameWorld.Config.Maps;
            _obstacles = gameWorld.Config.Obstacles;
        }

        public override void InstallBindings()
        {
            BindUnit();
            BindMap();
            BindObstacle();
            BindEffector();

            Container
                .Bind<SettingPosition>()
                .AsSingle();
        }

        private void BindUnit()
        {
            Container
                .Bind<UnitPool>()
                .AsSingle();

            Container
                .BindInterfacesTo<UnitService>()
                .AsSingle()
                .WithArguments(_units, _player, _delaySpawn);
        }

        private void BindMap()
        {
            Container
                .Bind<MapPool>()
                .AsSingle();

            Container
                .Bind<IMapService>()
                .To<MapService>()
                .AsSingle()
                .WithArguments(_maps, _maxSpawned);
        }

        private void BindObstacle()
        {
            Container
                .Bind<ObstaclePool>()
                .AsSingle();

            Container
                .BindInterfacesTo<ObstacleService>()
                .AsSingle()
                .WithArguments(_obstacles, _player, 1.5f);
        }

        private void BindEffector()
        {
            Container
                .Bind<EffectorPool>()
                .AsTransient();
        }
    }
}