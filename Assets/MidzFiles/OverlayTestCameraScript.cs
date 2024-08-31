using UnityEngine;

public class SyncCameraFOVTest : MonoBehaviour
{
    public Camera parentCamera; // Reference to the parent camera

    private Camera childCamera; // Reference to the child camera's Camera component

    void Start()
    {
        // Get the Camera component attached to this GameObject (child camera)
        childCamera = GetComponent<Camera>();

        if (parentCamera != null && childCamera != null)
        {
            // Copy the field of view from the parent camera to the child camera
            childCamera.fieldOfView = parentCamera.fieldOfView;
        }
        else
        {
            Debug.LogError("Parent camera or child camera component not found.");
        }
    }

    void Update()
    {
        // Optional: Update the child camera's FOV if the parent camera's FOV changes during runtime
        if (parentCamera != null && childCamera != null)
        {
            childCamera.fieldOfView = parentCamera.fieldOfView;
        }
    }
    
}