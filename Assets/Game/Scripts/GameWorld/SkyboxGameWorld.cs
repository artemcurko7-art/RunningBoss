using UnityEngine;
using Zenject;

namespace Game.Scripts.GameWorld
{
    public class SkyboxGameWorld : MonoBehaviour
    {
        [Inject]
        public void Construct(GameWorldProvider gameWorldProvider)
        {
            RenderSettings.skybox = gameWorldProvider.Config.Skybox;
            RenderSettings.ambientIntensity = gameWorldProvider.Config.SkyboxIntensityMultiplier;
            RenderSettings.fogColor = gameWorldProvider.Config.FogColor;
            RenderSettings.fogMode = gameWorldProvider.Config.FogMode;
            RenderSettings.fogDensity = gameWorldProvider.Config.FogDensity;
        }
    }
}