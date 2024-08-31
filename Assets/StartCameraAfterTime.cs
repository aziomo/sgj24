using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraAfterTime : MonoBehaviour{
    void Start(){
        StartCoroutine(StartCamera());
    }

    private IEnumerator StartCamera(){
        yield return new WaitForSeconds(3);
        GetComponent<UltimateCamera>().enabled = true;
        transform.position = new Vector3(transform.position.x, GetComponent<UltimateCamera>().offset.y, transform.position.z);
    }
}
