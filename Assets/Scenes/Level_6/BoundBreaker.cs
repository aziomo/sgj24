using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BoundBreaker : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Renderer>().bounds = new Bounds(Vector3.zero, Vector3.one * 1000f);
    }
}
