using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1024)]
public class FixedUpdateInterpolator : MonoBehaviour
{
    private Vector3 _previous, _current;
    private float _currentTime;

    private void Start()
    {
        _previous = transform.parent.position;
        _current = transform.parent.position;
    }

    private void FixedUpdate()
    {
        _previous = _current;
        _current = transform.parent.position;
        _currentTime = Time.time;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(_previous, _current, (Time.time - _currentTime) / Time.fixedDeltaTime);
    }
}
