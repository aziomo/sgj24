using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{

    public GameObject player;
    public float rotationSpeed = 10.0f;
    public float distance = 5.0f;

    public GameObject projectile;

    private GameObject barrel;

    private float reloadTime = 3.0f;
    private float timeLeftToReload = 0.0f;


    void Start(){
        barrel = GameObject.Find("Barrel");
    }


    void Update()
    {
        RaycastHit hit;
        Vector3 turretToPlayer = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, turretToPlayer, out hit)) {
            if (hit.collider.gameObject == player && hit.distance < distance) {

                Quaternion targetRotation = Quaternion.LookRotation(turretToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

                // napierdalanie
                timeLeftToReload -= Time.deltaTime;

                if (timeLeftToReload < 0){
                    var projectileObj = Instantiate(projectile, barrel.transform.position, transform.rotation);
                    projectileObj.GetComponent<RocketController>().projectileDirection = transform.rotation;


                    timeLeftToReload = reloadTime;
                } 

            }
        }
    }
}
