using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel = default;
    [SerializeField] float winDelay = 5f;

    private int enemyNumber = 0;
    private bool isTimerOver = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void EnemySpawned() { enemyNumber++; }

    public void EnemyKilled() 
    { 
        enemyNumber--;
        if (enemyNumber <= 0 && isTimerOver)
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

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelay);
        GetComponent<LevelLoader>().LoadNextLevel();
    }
}
