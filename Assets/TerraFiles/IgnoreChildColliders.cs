using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreChildColliders : MonoBehaviour{
    public void Start(){
        var colliders = GetComponentsInChildren<Collider>();
        for(int i = 0; i < colliders.Length; i++){
            for (int x = i+1; x < colliders.Length; x++){
                Physics.IgnoreCollision(colliders[i], colliders[x], true);
            }
        } 
    }
}
