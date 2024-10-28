using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10f;
    public float moveSpeed = 5f; // Speed of movement to the right
    private bool isAlive = true;

    private CameraFollow cameraFollow; // Reference to the CameraFollow script

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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
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
        // Make sure the player only jumps if they're on the ground
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

        // Optionally handle other death logic here (e.g., play an animation)
        Destroy(gameObject); // Destroy the character
    }

    private bool IsGrounded()
    {
        // Simple ground check (might need adjustments based on your game setup)
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
