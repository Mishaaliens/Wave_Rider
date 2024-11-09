using UnityEngine;

public class camerafollower : MonoBehaviour
{
    public Transform target;    // Reference to the ball
    public Vector3 offset;      // Offset distance between the camera and the ball
    public float smoothSpeed = 0.125f;  // Speed for smooth camera movement
    public float heightOffset = 2f;    // Height adjustment for the camera's position

    void LateUpdate()
    {
        // Calculate the desired position behind the ball, maintaining the X and Y offset
        Vector3 desiredPosition = target.position + offset;

        // Ensure the camera maintains a fixed height
        desiredPosition.y += heightOffset;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Ensure the camera looks at the ball
        transform.LookAt(target.position + Vector3.up * heightOffset);
    }
}
