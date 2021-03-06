﻿using System;
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
        OptionsMenu = 1,
        StartMenu = 2,
        Tutorial = 3,
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex == (int)Levels.SplashScreen)
        {
            PlayerPrefsController.SetGameDifficulty(2f);
            PlayerPrefsController.SetMasterVolume(0.5f);
            StartCoroutine(LoadWithDelay(Levels.StartMenu, secondsOnSplashScreen));
        }
    }
    public void LoadNextLevel()
    {
        int currentLevel = currentSceneIndex + 1 - (int)Levels.Tutorial;
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.ChangeSoundtrack(currentLevel);
        }
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.PlayCurrentSoundtrack();
        }
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.ChangeSoundtrack(0);
        }
        LoadLevel(Levels.StartMenu);
    }
    public void LoadOptionsMenu()
    {
        LoadLevel(Levels.OptionsMenu);
    }
    public void LoadTutorial()
    {
        LoadLevel(Levels.Tutorial);
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
