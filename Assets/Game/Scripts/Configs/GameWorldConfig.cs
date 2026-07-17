using Game.Scripts.PoolMono.ObjectPool.Map;
using Game.Scripts.PoolMono.ObjectPool.Obstacle;
using Game.Scripts.PoolMono.ObjectPool.Unit;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Source/Config/GameWorld", fileName = "GameWorldConfig", order = 0)]

    public class GameWorldConfig : ScriptableObject
    {
        [field: SerializeField] public Material Skybox { get; private set; }
        [field: SerializeField] public Unit[] Units { get; private set; }
        [field: SerializeField] public Map[] Maps { get; private set; }
        [field: SerializeField] public Obstacle[] Obstacles { get; private set; }
        [field: SerializeField] public FogMode FogMode { get; private set; }
        [field: SerializeField] public Color FogColor { get; private set; }
        [field: SerializeField] public float FogDensity { get; private set; }
        [field: SerializeField] public float SkyboxIntensityMultiplier { get; private set; }
    }
}