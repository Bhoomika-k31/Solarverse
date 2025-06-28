using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float rotationSpeed = 10f;  

    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
