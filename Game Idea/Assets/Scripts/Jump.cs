using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float jumpForce = 500f; // Adjust this value to control jump height
    public float fallMultiplier = 1f; // Controls fall speed

    Rigidbody rb;
    private bool isGrounded = true; // Tracks if player is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Jump()
    {
        isGrounded = false;
        rb.velocity = new Vector3(rb.velocity.x, 8, rb.velocity.z); // Reset y velocity before jumping
        rb.AddForce(Vector3.up * jumpForce);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set isGrounded to true when hitting the ground
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}



