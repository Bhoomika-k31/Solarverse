using UnityEngine;

public class FlyCam : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float boostMultiplier = 3f;
    public float lookSpeed = 3f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -89f, 89f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        
        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed *= boostMultiplier;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move += Vector3.up * (Input.GetKey(KeyCode.E) ? 1 : (Input.GetKey(KeyCode.Q) ? -1 : 0));

        transform.Translate(move * speed * Time.deltaTime, Space.Self);
    }
}
