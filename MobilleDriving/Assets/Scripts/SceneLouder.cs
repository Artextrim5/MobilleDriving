using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLouder : MonoBehaviour
{

    private int currentSceneIndex;


    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoudMainManu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void GameQuit()
    {
        Application.Quit();   
    }

}
