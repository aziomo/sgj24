using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UltimateCamera : MonoBehaviour{
    public Transform target;
    private CameraShake cam_math;
    public float smooth = 0.5f;
    public float zoom = 20f;
    public bool freeZSlave = false;
    protected Camera cam;
    public Vector3 offset;
    protected Vector3 velocity;
    public static UltimateCamera instance;
 
    void Awake(){
        instance = this;
        cam_math = GetComponent<CameraShake>();
        cam = GetComponent<Camera>();
    }
    public void StartCameraShake(float duration, float magnitude){
        cam_math.ResetShake(magnitude, duration);
    }
    private void FixedUpdate() {
        Move();
        Zoom();
    }
    void Move(){
        Vector3 newPosition = target.position + offset;

        if(!freeZSlave){
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
                newPosition.x += cam_math.CalculateShakeFunctionX(),
                newPosition.y += cam_math.CalculateShakeFunctionY(),
                transform.position.z), 
            ref velocity, smooth);
        }else{
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
                newPosition.x += cam_math.CalculateShakeFunctionX(),
                newPosition.y += cam_math.CalculateShakeFunctionY(),
                newPosition.z), 
            ref velocity, smooth);
            transform.LookAt(target.position);
        }
    }
    void Zoom(){
        cam.fieldOfView = Mathf.Clamp(Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime),1,70);
    }

}
