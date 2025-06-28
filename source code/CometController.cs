using UnityEngine;

public class CometController : MonoBehaviour
{
    [Header("Comet Speed")]
    public float speed = 50f;

    [Header("Rotation Drift")]
    public float driftAmount = 5f;

    [Header("Lifetime (seconds)")]
    public float lifetime = 20f;

    private float timer = 0f;

    void Update()
    {
       
        transform.position += transform.forward * speed * Time.deltaTime;

        
        transform.Rotate(Vector3.up, driftAmount * Time.deltaTime);

      
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
