using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Assign your cube to this in the Inspector
    public float yOffset = 2f;     // Offset along the Y-axis
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}