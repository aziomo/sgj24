using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    private StateMachineManager states;
    private GroundCheck groundCheck;
    private PlayerStats stats;

    public AudioClip crouch;
    public AudioClip stand;
    public AudioClip jump;

    public float addTimeCoyote = .5f;
    private float coyoteTimer = 0;
    private bool groundMemo = false;
    private bool wasCrouching = false;
    private float lastJumpSoundTime = 0;
    private void Awake(){
        states = GetComponent<StateMachineManager>();
        groundCheck = GetComponent<GroundCheck>();
        stats = GetComponent<PlayerStats>();
    }

    void Update(){
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"),0 , Input.GetAxisRaw("Vertical")).normalized;
        var inputJump = Input.GetAxis("Jump");
        var crouchInput = Input.GetKey(KeyCode.LeftControl);
        if(groundMemo && !groundCheck.CheckIfOnGround()){
            coyoteTimer = addTimeCoyote;
        }

        if(inputMovement != Vector3.zero){
            states.ChangeState(States.Move);
            RotatePlayerToMoveDirection();
        }else{
            states.ChangeState(States.Idle);
        }
      
        if(inputJump > 0 && (groundCheck.CheckIfOnGround() || coyoteTimer > 0)){
            if (lastJumpSoundTime + 0.5f < Time.fixedTime) {
                AudioSource.PlayClipAtPoint(jump, transform.position);
                lastJumpSoundTime = Time.fixedTime;
            }
            states.ChangeState(States.Jump);
            groundMemo = false;
        }else{
            groundMemo = groundCheck.CheckIfOnGround();
        }
        
        
        if(crouchInput){
            transform.localScale = new Vector3(1,.3f,1);
            if (!wasCrouching) {
                AudioSource.PlayClipAtPoint(crouch, transform.position);
            }
            wasCrouching = true;
            
        }else{
            transform.localScale = new Vector3(1,1,1);
            if (wasCrouching) {
                AudioSource.PlayClipAtPoint(stand, transform.position);
            }
            wasCrouching = false;
        }
        coyoteTimer -= Time.deltaTime;

        var forceNextLevel = Input.GetKey(KeyCode.L);
        if (forceNextLevel) {
            GameManager.Instance.PlayerWon();
        }
    }
    private void RotatePlayerToMoveDirection( ){
        var input = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical")).normalized;
        Quaternion currentRotation = GetComponent<Rigidbody>().rotation;
        Quaternion targetRotation = Quaternion.LookRotation(input.normalized);
        Quaternion smoothRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * stats.rotationSpeed);
        GetComponent<Rigidbody>().rotation = smoothRotation;
    }
}
