using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public int level = 1;
    public int[] levelWinCondition;
    private bool mapEnd = false;
    void Awake(){
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void OnLevelWasLoaded (int level) {
        mapEnd = false;
    }
    public void ResetLevel(){
        SceneManager.LoadScene(level);
        Destroy(this);
    }
    public void ConditionCalled(){
        if(mapEnd) return;
        levelWinCondition[level - 1] -= 1;
        if(0 == levelWinCondition[level - 1]){
            PlayerWon();
        }
    }
    private void PlayerWon(){
        mapEnd = true;
        level++;
        if(level - 1 == levelWinCondition.Length){
            Won();
            return;
        }
        SceneManager.LoadScene(level);
    }
    private void Won(){
        Debug.Log("won");
    }
}
