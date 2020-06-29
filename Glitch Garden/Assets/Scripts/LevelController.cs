using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel = default;
    [SerializeField] float winDelay = 5f;
    [SerializeField] GameObject loseLabel = default;

    private int enemyNumber = 0;
    private bool isTimerOver = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void EnemySpawned() { enemyNumber++; }

    public void EnemyKilled() 
    { 
        enemyNumber--;
        if (enemyNumber <= 0 && isTimerOver && Time.timeScale != 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    public void TimerFinished() { 
        isTimerOver = true;
        EnemySpawner[] spawnerArray = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        FindObjectOfType<MusicPlayer>().PlayLoserSound();
        Time.timeScale = 0;
    }

    private IEnumerator HandleWinCondition()
    {
        if (!winLabel) yield return true;
        winLabel.SetActive(true);

        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) musicPlayer.PlayWinnerSound();

        yield return new WaitForSeconds(winDelay);
        GetComponent<LevelLoader>().LoadNextLevel();
    }
}
