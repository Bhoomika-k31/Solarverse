using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityController : MonoBehaviour
{
    public float gravityForce = -9.81f;  

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.up * gravityForce, ForceMode.Acceleration);
    }
}
