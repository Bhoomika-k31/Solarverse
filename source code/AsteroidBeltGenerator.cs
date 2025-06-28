using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AsteroidBeltGenerator : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public GameObject asteroidPrefab;  
    public int numberOfAsteroids = 1000;

    [Header("Belt Radius")]
    public float innerRadius = 140f;
    public float outerRadius = 200f;
    public float height = 50f;

    [Header("Random Scale (Optional)")]
    public bool randomizeScale = false;
    public Vector2 scaleRange = new Vector2(0.5f, 2f);

    void Start()
    {
        GenerateAsteroids();
    }

    public void GenerateAsteroids()
    {
        
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            
            float angle = Random.Range(0f, 360f);
            float radius = Random.Range(innerRadius, outerRadius);
            float yOffset = Random.Range(-height / 2f, height / 2f);

            Vector3 position = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad) * radius,
                yOffset,
                Mathf.Sin(angle * Mathf.Deg2Rad) * radius
            );

            GameObject asteroid = Instantiate(asteroidPrefab, position, Random.rotation, transform);

            
            if (randomizeScale)
            {
                float scale = Random.Range(scaleRange.x, scaleRange.y);
                asteroid.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Generate Asteroids In Editor")]
    public void GenerateAsteroidsInEditor()
    {
        GenerateAsteroids();
        Debug.Log("Asteroid Belt generated in Editor.");
    }
#endif
}
