using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateCamera : MonoBehaviour{
    public Transform target;
    private CameraShake cam_math;
    public float smooth = 0.5f;
    public float zoom = 20f;
    public CameraMode currentCameraMode = CameraMode.Normal;
    [Range(0,1)]
    public int yMovement = 0;
    protected Camera cam;
    public Vector3 offset;
    public float rotationAngle = 0f;
    public float rotationSpeed = 10f;
    public float rotationSmooth = 1f;
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
    private void FixedUpdate(){
        if(currentCameraMode == CameraMode.Normal){
            MoveNormal();
        }
    }
    private void LateUpdate() {
        if(currentCameraMode == CameraMode.LookAtPlayer){
            MoveLookAtPlayer();
        }else if(currentCameraMode == CameraMode.Free){
            MoveZAxiesFree();
        }
        Zoom();
    }
    public void RotateAroundTarget(float angleDelta) {
        rotationAngle += angleDelta * rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
        Vector3 rotatedOffset = rotation * offset;
        transform.position = target.position + rotatedOffset;
    }
    private void MoveNormal(){
        Vector3 newPosition = target.position + offset;
        var y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
                newPosition.x + cam_math.CalculateShakeFunctionX(),
                y * yMovement  + newPosition.y * Mathf.Abs(yMovement - 1) + cam_math.CalculateShakeFunctionY() * Mathf.Abs(yMovement - 1),
                transform.position.z), 
        ref velocity, smooth);
    }
    private void MoveLookAtPlayer(){
        Vector3 newPosition = target.position + offset;
        var y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
                newPosition.x + cam_math.CalculateShakeFunctionX(),
                y * yMovement  + newPosition.y * Mathf.Abs(yMovement - 1) + cam_math.CalculateShakeFunctionY()* Mathf.Abs(yMovement - 1),
                transform.position.z), 
        ref velocity, smooth);
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        transform.LookAt(target.position);
    }
    private void MoveZAxiesFree(){
        var y = transform.position.y;
        Vector3 newPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(
            newPosition.x + cam_math.CalculateShakeFunctionX(),
            y * yMovement  + newPosition.y * Mathf.Abs(yMovement - 1) + cam_math.CalculateShakeFunctionY()* Mathf.Abs(yMovement - 1),
            newPosition.z), 
        ref velocity, smooth);
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
        transform.LookAt(target.position);
    }
    void Zoom(){
        cam.fieldOfView = Mathf.Clamp(Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime),1,70);
    }
}
public enum CameraMode{
    Normal,
    LookAtPlayer,
    Free
}
