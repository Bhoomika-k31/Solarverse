using UnityEngine;

[ExecuteAlways]
public class JupiterCloudEffect : MonoBehaviour
{
    public Material jupiterMaterial;
    public float swirlSpeed = 0.01f;

    private Vector2 uvOffset = Vector2.zero;

    void Update()
    {
        if (jupiterMaterial != null)
        {
            uvOffset.x += swirlSpeed * Time.deltaTime;
            uvOffset.y += swirlSpeed * 0.3f * Time.deltaTime;
            jupiterMaterial.SetTextureOffset("_BaseColorMap", uvOffset);
        }
    }
}
