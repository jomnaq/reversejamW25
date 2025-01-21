using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 500f;
    public float jumpForce = 5f;  
    public Transform groundCheck; 
    public float groundDistance = 0.6f; 
    public LayerMask groundMask; 

    private Rigidbody rb;
    private bool isGrounded;
    private float xRotation = 0f;
    private Vector3 velocity;

    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = playerBody.GetComponent<Rigidbody>();  // Player Rigidbody
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        velocity = move * speed;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundMask);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
