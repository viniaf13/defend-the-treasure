using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float secondsOnSplashScreen = 3f;
    [SerializeField] float switchLevelsDelay = 2f;

    private int currentSceneIndex;

    private enum Levels
    {
        SplashScreen = 0,
        StartMenu = 1,
        GameOver = 2,
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

    public void LoadGameOver()
    {
        StartCoroutine(LoadWithDelay(Levels.GameOver, switchLevelsDelay));
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
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
