using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public int level = 1;
    void Awake(){
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public void ResetLevel(){
        SceneManager.LoadScene(level);
        Destroy(this);
    }
    private void PlayerWon(){
        level++;
        SceneManager.LoadScene(level);
    }
}
