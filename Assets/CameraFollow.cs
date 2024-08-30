// 2024-08-30 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public Vector3 offset = new Vector3(0, 5, -10); // Adjustable offset from the player
    public float smoothSpeed = 0.125f; // Speed of the camera's interpolation

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player); // Ensure the camera always faces the player
    }
}
