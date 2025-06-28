using UnityEngine;

public class AdvancedCometSpawner : MonoBehaviour
{
    [Header("Comet Settings")]
    public GameObject cometPrefab;
    public Transform targetPoint; 
    public float spawnRadius = 600f;

    [Header("Timing")]
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 15f;

    [Header("Comet Speed")]
    public float minSpeed = 30f;
    public float maxSpeed = 70f;

    [Header("Comet Lifetime")]
    public float cometLifetime = 20f;

    private float spawnTimer = 0f;
    private float nextSpawnTime = 0f;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= nextSpawnTime)
        {
            SpawnComet();
            ScheduleNextSpawn();
        }
    }

    void ScheduleNextSpawn()
    {
        spawnTimer = 0f;
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void SpawnComet()
    {
        
        float angle = Random.Range(0f, 360f);
        Vector3 spawnPosition = new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius,
            Random.Range(-spawnRadius / 2f, spawnRadius / 2f),
            Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius
        );

        
        GameObject comet = Instantiate(cometPrefab, spawnPosition, Quaternion.LookRotation((targetPoint.position - spawnPosition).normalized));

        
        CometController controller = comet.GetComponent<CometController>();
        if (controller != null)
        {
            controller.speed = Random.Range(minSpeed, maxSpeed);
            controller.lifetime = cometLifetime;
        }
    }
}
