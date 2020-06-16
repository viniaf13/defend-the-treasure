using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int enemyNumber = 0;
    private bool isTimerOver = false;

    public void EnemySpawned() { enemyNumber++; }

    public void EnemyKilled() 
    { 
        enemyNumber--;
        if (enemyNumber <= 0 && isTimerOver)
        {
            GetComponent<LevelLoader>().LoadGameOver(); //TODO WIN SCREEN
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
}
