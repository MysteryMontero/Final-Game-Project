using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the player in the Inspector
    public Vector3 offset; // Set the desired offset in the Inspector
    public float followSpeed = 10f;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }
}
