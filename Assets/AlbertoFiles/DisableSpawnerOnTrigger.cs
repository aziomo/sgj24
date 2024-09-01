using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnerOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spawner;

    private void OnTriggerEnter(Collider other) {
        Destroy(spawner);
        gameObject.SetActive(false);
    }
}
