using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int enemyNumber = 0;

    public void EnemySpawned() { enemyNumber++; }

    public void EnemyKilled() 
    { 
        enemyNumber--;
        if (enemyNumber <= 0 && FindObjectOfType<GameTimer>().IsLevelOver())
        {
            GetComponent<LevelLoader>().LoadGameOver(); //TODO WIN SCREEN
        }
    }
}
