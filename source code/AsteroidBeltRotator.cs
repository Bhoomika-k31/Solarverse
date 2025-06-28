using UnityEngine;

public class AsteroidBeltRotator : MonoBehaviour
{
    [Header("Rotation Speed (degrees per second)")]
    public float rotationSpeed = 5f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
