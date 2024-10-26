using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10f;
    private bool isAlive = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isAlive && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
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
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.target = null;
        }
        Destroy(gameObject); // Destroy the character
        // Add your death logic here (e.g., play an animation, restart the level)
        //GameManager.Instance.RestartLevel(); // Assuming you have a GameManager to restart the level
    }

    private bool IsGrounded()
    {
        // Simple ground check (might need adjustments based on your game setup)
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
