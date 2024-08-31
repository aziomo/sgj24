using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoCaughtEvent : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Catchable")) {
            other.transform.parent.GetComponent<OgreCowController>().isCaught = true;
            player.GetComponent<LassoController>().caughtCow = other.transform.parent;
        }
    }

}
