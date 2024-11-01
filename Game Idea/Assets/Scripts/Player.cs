using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 0f;
    public float moveSpeed = 5f; // Speed of movement to the right
    private bool isAlive = true;
    private bool isGrounded = true; // Tracks if player is grounded

    private CameraFollow cameraFollow; // Reference to the CameraFollow script
    public float fallMultiplier = 1f; // Controls fall speed

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the camera target to this player instance
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.target = transform; // Set the camera target to the player's transform
        }
    }

    private void Update()
    {
        if (isAlive)
        {
            MoveRight();

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            // Faster fall when coming down from a jump
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    private void MoveRight()
    {
        // Move the character to the right at a fixed speed
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        isGrounded = false;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset y velocity before jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set isGrounded to true when hitting the ground
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAlive && other.CompareTag("Spike")) // Check for collision with spikes
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.PlayerDied();
        isAlive = false;

        // Stop the camera from following
        if (cameraFollow != null)
        {
            cameraFollow.target = null; // Set the target to null to stop following
        }

        // Destroy the character
        Destroy(gameObject);
    }
}