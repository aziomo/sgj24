using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 10.0f;
    public float viewDistance = 5.0f;
    public float reloadTime = 3.0f;

    public GameObject projectile;
    public GameObject barrel;

    public int projectilesInSeries = 1;
    public float seriesTimeGap = 0.25f;
    private int projectilesLeftInMag;
    
    private float timeLeftToReload = 0.0f;
    private float timeLeftInSeriesTimeGap;

    void Start() {
        projectilesLeftInMag = projectilesInSeries;
        timeLeftInSeriesTimeGap = seriesTimeGap;
    }
    
    // in degrees
    public float fovAngle = 45f;
    bool isAggroed = false;

    bool isPlayerInFov() {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        return Vector3.Angle(transform.forward, directionToPlayer) < (fovAngle/2.0);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 directionToPlayer = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit)) {

            if (hit.collider.gameObject == player && hit.distance < viewDistance) // if player is in range
            {

                if (isPlayerInFov())
                {
                    isAggroed = true;
                }
                
                if (isAggroed){
                    // obrot
                    Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
 
                    // strzelanie

                    timeLeftToReload -= Time.deltaTime;
                    
                    if (timeLeftToReload < 0) {

                        if (projectilesLeftInMag > 0){

                            timeLeftInSeriesTimeGap -= Time.deltaTime;

                            if (timeLeftInSeriesTimeGap < 0) {
                                var projectileObj = Instantiate(projectile, barrel.transform.position, transform.rotation);
                                projectileObj.GetComponent<RocketController>().projectileDirection = transform.rotation;
                                
                                timeLeftInSeriesTimeGap = seriesTimeGap;
                                projectilesLeftInMag -= 1;
                            }

                        } else {
                            timeLeftToReload = reloadTime;
                            projectilesLeftInMag = projectilesInSeries;
                        }


                        
                    }
                }

            } else {
                isAggroed = false;
            }
            
        }
    }
}
