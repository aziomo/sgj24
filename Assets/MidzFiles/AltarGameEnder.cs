using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarGameEnder : MonoBehaviour, IInteract{
    private Transform player;
    public Sprite placeholderSprite;
    public float heightOffset = 1f;
    public float detectionRange = 3f;


    float distanceToPlayer = 5f;
    float angle = 0f;


    private GameObject spriteObject;
    private SpriteRenderer spriteRenderer;

    private bool displaylock = false;


    public bool explode = true;

    public Vector3 offset = new Vector3(2, 2, 0);


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
    }
    public GameObject GetObjectReference(){
        return gameObject;
    }
    public void Interact()
    {

        if (distanceToPlayer < detectionRange & angle < 45)
        {


            if (explode == true)
            {
                StartCoroutine(Explode());
                displaylock = true;
            }





        }

    }


    private IEnumerator Explode(){
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.ConditionCalled();
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        */



        distanceToPlayer = Vector3.Distance(transform.position, player.position);


        Vector3 playerForwardXZ = new Vector3(player.forward.x, 0, player.forward.z).normalized;

        // Vector from player to target in XZ plane
        Vector3 toTargetXZ = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;

        // Calculate the angle between the two vectors
        angle = Vector3.Angle(playerForwardXZ, toTargetXZ);



        if (distanceToPlayer < detectionRange & angle < 45 & displaylock == false)
        {
            if (spriteObject == null)
            {
                // Create the sprite object if it doesn't already exist
                spriteObject = new GameObject("PlaceholderSprite");

                // Add a SpriteRenderer component
                spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();

                // Set the sprite
                spriteRenderer.sprite = placeholderSprite;

                // Set the position of the new sprite on top of the current object
                spriteObject.transform.position = transform.position;

                // Set rotation
                spriteObject.transform.rotation = Quaternion.Euler(45, 0, 0);

                int layerIndex = LayerMask.NameToLayer("AlwaysOnTop");

                spriteObject.layer = layerIndex;

                //Debug.Log("Layer = " + layerIndex);
            }

            spriteObject.transform.position = transform.position + offset;



        }
        else
        {
            if (spriteObject != null)
            {
                // Destroy the sprite if the player moves away
                Destroy(spriteObject);
                spriteObject = null; // Reset the spriteObject reference
            }
        }
    }





}