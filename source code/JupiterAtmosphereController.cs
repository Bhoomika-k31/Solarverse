using UnityEngine;

[ExecuteAlways]
public class JupiterAtmosphereController : MonoBehaviour
{
    [Header("Main Cloud Material")]
    public Material cloudMaterial;

    [Header("Storm Overlay (Optional)")]
    public Texture2D stormTexture;
    public float stormScrollSpeed = 0.05f;

    [Header("Cloud Swirl Settings")]
    public float swirlSpeedX = 0.01f;
    public float swirlSpeedY = 0.005f;

    [Header("Lightning Settings")]
    public Light lightningFlash;
    public float flashInterval = 5f;
    public float flashDuration = 0.2f;
    private float flashTimer = 0f;
    private bool isFlashing = false;

    private Vector2 uvOffset = Vector2.zero;

    void Update()
    {
        
        if (cloudMaterial != null)
        {
            uvOffset.x += swirlSpeedX * Time.deltaTime;
            uvOffset.y += swirlSpeedY * Time.deltaTime;
            cloudMaterial.SetTextureOffset("_BaseColorMap", uvOffset);

            if (stormTexture != null)
                cloudMaterial.SetTexture("_EmissiveColorMap", stormTexture); 
        }

        
        if (lightningFlash != null)
        {
            flashTimer += Time.deltaTime;

            if (!isFlashing && flashTimer >= flashInterval)
            {
                lightningFlash.enabled = true;
                isFlashing = true;
                flashTimer = 0f;
            }
            else if (isFlashing && flashTimer >= flashDuration)
            {
                lightningFlash.enabled = false;
                isFlashing = false;
                flashTimer = 0f;
            }
        }
    }
}
