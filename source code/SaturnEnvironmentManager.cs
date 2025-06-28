using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SaturnEnvironmentManager : MonoBehaviour
{
    void Start()
    {
        
        RenderSettings.fog = true;
        RenderSettings.fogColor = new Color(0.85f, 0.87f, 0.92f);
        RenderSettings.fogDensity = 0.005f;

        
        GameObject sun = new GameObject("SaturnSun");
        Light light = sun.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.2f;
        light.color = new Color(1f, 0.9f, 0.75f);
        sun.transform.rotation = Quaternion.Euler(50, -30, 0);
    }
}
