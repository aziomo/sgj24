using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6CC : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector2 _movementRange;
    [SerializeField] private Vector3 _deathback;

    private void Update()
    {
        var position = transform.position;

        if (Input.GetKey(KeyCode.A))
            position.x -= Time.deltaTime * _movementSpeed;

        if (Input.GetKey(KeyCode.D))
            position.x += Time.deltaTime * _movementSpeed;

        position.x = Mathf.Clamp(position.x, _movementRange.x, _movementRange.y);

        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = _deathback;

        GameManager.Instance.ResetLevel();

        enabled = false;
    }
}
