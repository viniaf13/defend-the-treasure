using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] EnemyPrefabArray = default;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    private bool keepSpawning = true;
    private IEnumerator Start()
    {
        while (keepSpawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, EnemyPrefabArray.Length);

        Enemy newEnemy = Instantiate
            (EnemyPrefabArray[enemyIndex], transform.position, Quaternion.identity) as Enemy;
        newEnemy.transform.parent = transform;
    }
}
