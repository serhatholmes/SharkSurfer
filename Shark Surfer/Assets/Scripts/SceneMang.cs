using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMang : MonoBehaviour
{
    public GameObject beforeStartPanel;
    public GameObject gameplayPanel;

    public GameObject endPanel;
    void Start()
    {
        Time.timeScale = 0;
        beforeStartPanel.SetActive(true);
        gameplayPanel.SetActive(false);
    }

    public void StartButton(){
        beforeStartPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void RestartButton(){

    }

    
}
