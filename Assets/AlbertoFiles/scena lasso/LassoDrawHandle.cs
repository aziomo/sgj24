using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoDrawHandle : MonoBehaviour
{
    public GameObject handle;
    public Transform lassoHandleStartPoint;
    public Transform lassoHandleEndPoint;

    void Start()
    {
        handle.GetComponent<LineRenderer>().SetPosition(0, lassoHandleStartPoint.position);
    }


    void Update()
    {
        handle.GetComponent<LineRenderer>().SetPosition(0, lassoHandleStartPoint.position);
        handle.GetComponent<LineRenderer>().SetPosition(1, lassoHandleEndPoint.position);
    }
}
