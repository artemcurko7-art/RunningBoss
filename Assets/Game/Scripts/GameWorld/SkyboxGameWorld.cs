using UnityEngine;
using Zenject;

public class SkyboxGameWorld : MonoBehaviour
{
    [Inject]
    public void Construct(GameWorld gameWorld)
    {
        RenderSettings.skybox = gameWorld.Config.Skybox;
        RenderSettings.ambientIntensity = gameWorld.Config.SkyboxIntensityMultiplier;
        RenderSettings.fogColor = gameWorld.Config.FogColor;
        RenderSettings.fogMode = gameWorld.Config.FogMode;
        RenderSettings.fogDensity = gameWorld.Config.FogDensity;
    }
}