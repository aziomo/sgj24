using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour{
    public static PlayerStats instance;
    public float speed = 1;
    public float jumpForce = 2;
    private void Awake(){
        instance = this;
    }
}
