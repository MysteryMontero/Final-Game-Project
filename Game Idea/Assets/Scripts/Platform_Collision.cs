using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_collosion : MonoBehaviour
{
    public LayerMask deadlyObjects;  // Set this to the layer your deadly objects are on

    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component on the player
        rb = GetComponent<Rigidbody>();

        // Set the collision detection mode to Continuous to avoid passing through objects at high speed
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a deadly object layer
        if (((1 << collision.gameObject.layer) & deadlyObjects) != 0)
        {
            // Get the contact point of the collision
            ContactPoint contact = collision.contacts[0];
            Vector3 contactPoint = contact.point;

            // Determine the center of the object
            Vector3 objectCenter = collision.collider.bounds.center;

            // Calculate relative position of the player to the object's center
            float relativeX = contactPoint.x - objectCenter.x;

            // Check if the collision happened on the left side of the object
            if (relativeX < 0) // Player hits the left side of the object
            {
                Die();  // Trigger the "death" function
            }
            else
            {
                // Stop player movement if it hits any other side
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Implement your death logic here (e.g., restart level, reduce lives, etc.)
    }
}
