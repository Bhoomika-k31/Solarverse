using UnityEngine;

public class CometGenerator : MonoBehaviour
{
    [Header("Comet Settings")]
    public GameObject cometPrefab;
    public int numberOfComets = 5;

    [Header("Spawn Radius")]
    public float spawnRadius = 500f;

    [Header("Comet Speed")]
    public float cometSpeed = 50f;

    void Start()
    {
        GenerateComets();
    }

    void GenerateComets()
    {
        for (int i = 0; i < numberOfComets; i++)
        {
            float angle = Random.Range(0f, 360f);
            Vector3 spawnPosition = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius,
                Random.Range(-spawnRadius / 2f, spawnRadius / 2f),
                Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius
            );

            GameObject comet = Instantiate(cometPrefab, spawnPosition, Quaternion.identity);

           
            Rigidbody rb = comet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (Vector3.zero - spawnPosition).normalized;
                rb.velocity = direction * cometSpeed;
            }
        }
    }
}
