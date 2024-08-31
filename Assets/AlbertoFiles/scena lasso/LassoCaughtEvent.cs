using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoCaughtEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Catchable")) {
            print("CAUGHT!!!");
        }
    }

}
