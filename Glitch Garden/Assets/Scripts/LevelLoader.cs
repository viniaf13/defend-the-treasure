using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float secondsOnSplashScreen = 3f;

    private enum Levels
    {
        SplashScreen = 0,
        StartMenu = 1,
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int) Levels.SplashScreen)
        {
            StartCoroutine(LoadMainMenu());
        }
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(secondsOnSplashScreen);
        LoadLevel(Levels.StartMenu);
    }

    private void LoadLevel(Levels level)
    {
        SceneManager.LoadScene((int) level);
    }

   
}
