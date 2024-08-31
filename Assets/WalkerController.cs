using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WalkerController : MonoBehaviour
{

    List<GameObject> navPoints;
    int navPointCounter = 0; 

    GameObject pathCollider;

    public LineRenderer path;
    private bool walkBack = false;
    public float speed = 5.0f;
    

    void Start()
    {
        pathCollider = GameObject.Find("PathCollider");
    }

    public bool IsPointWithinCollider(Collider collider, Vector3 point) { 
        return (collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon; 
    }

    void Update()
    {
        var pointTo = path.GetPosition(navPointCounter) + path.transform.position;
        pointTo.y = transform.position.y;

        float step = speed * Time.deltaTime; // calculate distance to move

        transform.position = Vector3.MoveTowards(transform.position, pointTo, step);
        if ((pointTo - transform.position).magnitude > 0.1){
            transform.rotation = Quaternion.LookRotation(pointTo - transform.position, Vector3.up);
        }

        if (IsPointWithinCollider(pathCollider.GetComponent<SphereCollider>(), pointTo)){
            print("walker reached the point");
            
            if (walkBack){
                navPointCounter -= 1;
            } else {
                navPointCounter += 1;
            }
            

            if (navPointCounter == 0) {
                walkBack = false;
            }
            if (navPointCounter == path.positionCount - 1) {
                walkBack = true;
            }


        }


    }

}
