using UnityEngine;

public class RingRotator : MonoBehaviour
{
    [Header("Rotation speed in degrees per second")]
    public float rotationSpeed = 2f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
