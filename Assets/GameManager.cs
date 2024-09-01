using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public int level = 1;
    public int[] levelWinCondition;
    public int levelWinConditionCurrent;
    private bool mapEnd = false;
    [SerializeField, Multiline] private string[] _winMessages;
    [SerializeField] private Text _winTex;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _deathScreen;
    private bool _waitingForSceneLoad;
    void Awake()
    {
        levelWinConditionCurrent = levelWinCondition[0];
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void OnLevelWasLoaded (int level) {
        mapEnd = false;
    }
    public void ResetLevel()
    {
        if (_waitingForSceneLoad)
            return;
        //SceneManager.LoadScene(level);
        _deathScreen.SetActive(true);
        StartCoroutine(DelayedSceneLoad(level, level == 1));
        //Destroy(this);
    }
    public void ConditionCalled(){
        if (_waitingForSceneLoad)
            return;
        if(mapEnd) return;
        levelWinConditionCurrent -= 1;
        if(0 == levelWinConditionCurrent){
            PlayerWon();
        }
    }
    public void PlayerWon(){
        if (_waitingForSceneLoad)
            return;
        mapEnd = true;
        _winTex.text = _winMessages[level];
        level++;
        if(level - 1 == levelWinCondition.Length){
            Won();
            return;
        }
        //SceneManager.LoadScene(level);
        _winScreen.SetActive(true);
        StartCoroutine(DelayedSceneLoad(level, false));
    }
    private void Won(){
        Debug.Log("won");
    }

    IEnumerator DelayedSceneLoad(int level, bool destroy)
    {
        _waitingForSceneLoad = true;
        
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(level);
        
        _winScreen.SetActive(false);
        _deathScreen.SetActive(false);

        levelWinConditionCurrent = levelWinCondition[level - 1];
        
        if(destroy)
            Destroy(this);
        
        _waitingForSceneLoad = false;
    }
}
