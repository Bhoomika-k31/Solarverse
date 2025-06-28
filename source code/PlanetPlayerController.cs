using UnityEngine;

public class PlanetPlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    public float walkSpeed = 5f;
    public float flySpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -3.7f; 

    public GameObject footstepVFX;
    public Transform footstepSpawnPoint;
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;

    private Vector3 velocity;
    private bool isGrounded;
    private bool ghostMode = false;
    private float stepTimer = 0f;
    private float stepInterval = 0.4f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ghostMode = !ghostMode;
            velocity = Vector3.zero;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = cameraTransform.forward * z + cameraTransform.right * x;
        move.y = 0f; 

        if (ghostMode)
        {
            float vertical = 0;
            if (Input.GetKey(KeyCode.E)) vertical = 1;
            if (Input.GetKey(KeyCode.Q)) vertical = -1;
            Vector3 flyMove = move.normalized + Vector3.up * vertical;
            controller.Move(flyMove * flySpeed * Time.deltaTime);
        }
        else
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
                velocity.y = -2f;

            controller.Move(move.normalized * walkSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            
            if (controller.velocity.magnitude > 0.1f && isGrounded)
            {
                stepTimer += Time.deltaTime;
                if (stepTimer >= stepInterval)
                {
                    if (footstepVFX && footstepSpawnPoint)
                        Instantiate(footstepVFX, footstepSpawnPoint.position, Quaternion.identity);
                    stepTimer = 0f;
                }
            }
        }

        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -85f, 85f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }
}
