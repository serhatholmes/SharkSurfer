using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMang : MonoBehaviour
{
    public GameObject beforeStartPanel;
    public GameObject gameplayPanel;

    public GameObject endPanel;

    public bool isStart = false; 
    void Start()
    {
        
        Time.timeScale = 0;
        beforeStartPanel.SetActive(true);
        gameplayPanel.SetActive(false);
    }

    public void StartButton(){
        isStart = true;
        beforeStartPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void RestartButton(){
        isStart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    
}
