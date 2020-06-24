using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float secondsOnSplashScreen = 3f;

    private int currentSceneIndex;

    private enum Levels
    {
        SplashScreen = 0,
        StartMenu = 1,
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex == (int)Levels.SplashScreen)
        {
            StartCoroutine(LoadWithDelay(Levels.StartMenu, secondsOnSplashScreen));
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        LoadLevel(Levels.StartMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadWithDelay(Levels level, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadLevel(level);
    }

    private void LoadLevel(Levels level)
    {
        SceneManager.LoadScene((int) level);
    } 
}
