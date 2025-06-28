using UnityEngine;

public class SaturnCloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public int numberOfClouds = 12;
    public float spawnRadius = 55f;
    public float verticalOffset = 8f;

    void Start()
    {
        for (int i = 0; i < numberOfClouds; i++)
        {
            Vector3 pos = UnityEngine.Random.onUnitSphere * spawnRadius;
            pos.y = Mathf.Abs(pos.y) + verticalOffset;
            Instantiate(cloudPrefab, pos, Quaternion.identity, transform);
        }
    }
}
