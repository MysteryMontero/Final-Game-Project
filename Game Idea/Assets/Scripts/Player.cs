using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;      // Speed of movement to the right
    private bool isAlive = true;
    private bool isGrounded = true;   // Tracks if player is grounded

    private CameraFollow cameraFollow; // Reference to the CameraFollow script

    public float initialJumpForce = 10f;    // Initial force when jump starts
    public float holdJumpForce = 5f;        // Force applied while holding jump
    public float maxJumpTime = 0.3f;        // Maximum time to allow holding jump
    private float jumpTimeCounter;          // Counter for jump time
    private bool isJumping = false;         // Tracks if player is jumping

    public float fallMultiplier = 1f; // Controls fall speed

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the camera target to this player instance
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.target = transform;
        }
    }

    private void Update()
    {
        if (isAlive)
        {
            MoveRight();

            // Jump input check
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = 0f;
                rb.velocity = new Vector3(rb.velocity.x, initialJumpForce, rb.velocity.z);
            }

            // Continue jumping if holding space and within max jump time
            if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimeCounter < maxJumpTime)
            {
                rb.AddForce(Vector3.up * holdJumpForce, ForceMode.Acceleration);
                jumpTimeCounter += Time.deltaTime;
            }

            // Stop jump if button is released or max jump time reached
            if (Input.GetKeyUp(KeyCode.Space) || jumpTimeCounter >= maxJumpTime)
            {
                isJumping = false;
            }

            // Apply faster fall
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }

        }
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            GameManager.Instance.LevelCompleted();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAlive && other.CompareTag("Spike"))
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
            cameraFollow.target = null;
        }

        Destroy(gameObject);
    }
}