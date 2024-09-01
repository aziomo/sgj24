using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour
{
    public static Sausage Active;

    private void Awake()
    {
        Active = this;
    }
}
