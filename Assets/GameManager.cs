using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public int level = 0;
    void Awake(){
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public void ResetLevel(){
        
        Destroy(this);
    }

    void Update(){
        
    }
}
