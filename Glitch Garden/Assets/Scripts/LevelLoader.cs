using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float secondsOnSplashScreen = 3f;
    [SerializeField] float switchLevelsDelay = 2f;

    private enum Levels
    {
        SplashScreen = 0,
        StartMenu = 1,
        GameOver = 2,
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)Levels.SplashScreen)
        {
            StartCoroutine(LoadWithDelay(Levels.StartMenu, secondsOnSplashScreen));
        }
    }

    private IEnumerator LoadWithDelay(Levels level, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadLevel(level);
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadWithDelay(Levels.GameOver, switchLevelsDelay));
    }

    private void LoadLevel(Levels level)
    {
        SceneManager.LoadScene((int) level);
    }

   
}
