using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleI : MonoBehaviour, IInteract
{
    private Transform player;
    public Sprite placeholderSprite;
    public float heightOffset = 1f;
    public float detectionRange = 3f;


    float distanceToPlayer = 5f;
    float angle = 0f;


    private GameObject spriteObject;
    private SpriteRenderer spriteRenderer;

    private bool displaylock = false;

    public Vector3 offset = new Vector3(1,1,1);

    public float scale1 = 1f;

    [SerializeField] private GameObject _explosionVfx;
    
    private OgreCowController Cow;

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


        Cow = GetComponent<OgreCowController>();


    }
    public GameObject GetObjectReference(){
        return gameObject;
    }
    public void Interact(){
        if (Cow.isCaught && !displaylock){
            StartCoroutine(Explode());
            displaylock = true;
        }
    }


    private IEnumerator Explode(){
        float elapsedTime3 = 0f;
        while (elapsedTime3 < 2){
            transform.localScale += Vector3.one * Time.deltaTime;
            elapsedTime3 += Time.deltaTime;
            yield return null;
        }

        Instantiate(_explosionVfx, transform.position, Quaternion.identity);
        GameManager.Instance.ConditionCalled();
        Destroy(gameObject);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        */
        //if(displaylock) return;



            distanceToPlayer = Vector3.Distance(transform.position, player.position);
     

        Vector3 playerForwardXZ = new Vector3(player.forward.x, 0, player.forward.z).normalized;

        // Vector from player to target in XZ plane
        Vector3 toTargetXZ = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;

        // Calculate the angle between the two vectors
        angle = Vector3.Angle(playerForwardXZ, toTargetXZ);

        

        if (distanceToPlayer < detectionRange & angle < 45 & displaylock == false & Cow.isCaught)
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
                spriteObject.transform.position = transform.position + offset;

                // Set rotation
                spriteObject.transform.rotation = Quaternion.Euler(45, 0, 0);

                int layerIndex = LayerMask.NameToLayer("AlwaysOnTop");

                spriteObject.layer = layerIndex;

                //Debug.Log("Layer = " + layerIndex);
            }

            spriteObject.transform.position = transform.position + offset;
            spriteObject.transform.localScale = new Vector3(scale1, scale1, scale1);


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