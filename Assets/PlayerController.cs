// 2024-08-30 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * speed);

        if (movement != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, rotation, Time.fixedDeltaTime * 10);
        }
    }
}
