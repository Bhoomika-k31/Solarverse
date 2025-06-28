using UnityEngine;

public class SpawnNearEarth : MonoBehaviour
{
    public Transform earth;  
    public float distanceFromEarth = 50f;

    void Start()
    {
        if (earth != null)
        {
            
            Vector3 spawnDirection = -earth.forward;  
            transform.position = earth.position + spawnDirection * distanceFromEarth;

            
            transform.LookAt(earth.position);
        }
        else
        {
            Debug.LogWarning("Earth object not assigned in SpawnNearEarth script!");
        }
    }
}
