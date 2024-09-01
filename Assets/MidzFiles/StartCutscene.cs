using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour, IInteract
{
    private Transform player;

    private Transform camera1;

    public Vector3 newcameraposition = new Vector3(0f, 0f, 0f);

    public float detectionRange = 3f;

    float distanceToPlayer = 5f;
    float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.instance != null)
        {
            player = PlayerStats.instance.transform;
        }
        else
        {
            Debug.LogError("PlayerStats singleton instance not found!");
        }

        if (UltimateCamera.instance != null)
        {
            camera1 = UltimateCamera.instance.transform;
        }
        else
        {
            Debug.LogError("UltimateCamera singleton instance not found!");
        }

    }
      public GameObject GetObjectReference(){
        return gameObject;
    }
    public void Interact()
    {

        if (distanceToPlayer < detectionRange & angle < 45)
        {
            Debug.Log("Itworks");
            StartCoroutine(Stopper());





        }

    }




    IEnumerator Stopper()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 2)
        {
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        playerInput.enabled = false;


        StateMachineManager stateMachineManager = player.GetComponent<StateMachineManager>();

        if (stateMachineManager != null)
        {

            stateMachineManager.ChangeState(States.Idle, true);

            // Disable the StateMachineManager script
            stateMachineManager.enabled = false;
            Debug.Log("StateMachineManager script disabled.");
        }


        camera1.transform.position = newcameraposition;

        UltimateCamera camerascript = camera1.GetComponent<UltimateCamera>();
        camerascript.enabled = false;






    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector3.Distance(transform.position, player.position);


        Vector3 playerForwardXZ = new Vector3(player.forward.x, 0, player.forward.z).normalized;

        // Vector from player to target in XZ plane
        Vector3 toTargetXZ = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;

        // Calculate the angle between the two vectors
        angle = Vector3.Angle(playerForwardXZ, toTargetXZ);

    }
}
