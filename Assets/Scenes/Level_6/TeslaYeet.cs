using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaYeet : MonoBehaviour
{
    [SerializeField] private float _yeetSpeed;
    [SerializeField] private float _lifetime;

    private float _death;

    private void OnEnable()
    {
        _death = Time.time + _lifetime;
    }

    private void Update()
    {
        if (Time.time > _death)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += Vector3.forward * _yeetSpeed * Time.deltaTime;
        }
    }
}
