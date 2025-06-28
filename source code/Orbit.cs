using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform orbitCenter;    
    public float orbitSpeed = 10f;   

    void Update()
    {
        if (orbitCenter != null)
        {
            transform.RotateAround(orbitCenter.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}
