using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoCaughtEvent : MonoBehaviour
{
    public AudioClip moo;
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Catchable")) {
            AudioSource.PlayClipAtPoint(moo, transform.position);
            other.transform.parent.GetComponent<OgreCowController>().isCaught = true;
            player.GetComponent<LassoController>().caughtCow = other.transform.parent;
        }
    }

}
